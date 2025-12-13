using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace proyFinalAgropecuaria
{
    internal class BDAgro
    {
        public readonly string connectionDB;
        private static BDAgro? instance;
        public BDAgro()
        {
            string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataFolder);

            connectionDB = Path.Combine(dataFolder, "agro.db");

            CrearBDyTablas();
        }

        public static BDAgro FromStatic()
        {
            if (instance == null)
            {
                instance = new BDAgro();
            }
            return instance;
        }

        private void CrearBDyTablas()
        {
            using var conn = new SqliteConnection($"Data Source={connectionDB}");
            conn.Open();
            using var cmd = conn.CreateCommand();

            // Tabla Productos
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Productos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Descripcion TEXT,
                    Precio REAL
                );";
            cmd.ExecuteNonQuery();

            // Tabla Clientes
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Clientes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Direccion TEXT,
                    Telefono TEXT,
                    Email TEXT,
                    TipoCliente TEXT CHECK(TipoCliente IN ('Minorista','Mayorista'))
                );";
            cmd.ExecuteNonQuery();

            // Tabla Proveedores
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Proveedores (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Telefono TEXT,
                    Email TEXT,
                    Direccion TEXT
                );";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Compras (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                ProveedorId INTEGER NOT NULL,
                                Fecha TEXT NOT NULL,
                                Total REAL NOT NULL,

                                FOREIGN KEY (ProveedorId) REFERENCES Proveedores(Id)
                            );";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS DetalleCompras (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                CompraId INTEGER NOT NULL,
                                ProductoId INTEGER NOT NULL,
                                Cantidad INTEGER NOT NULL,
                                PrecioUnitario REAL NOT NULL,
                                Subtotal REAL NOT NULL,

                                FOREIGN KEY (CompraId) REFERENCES Compras(Id),
                                FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
                            );";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Ventas (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                ClienteId INTEGER NOT NULL,
                                Fecha TEXT NOT NULL,
                                Total REAL NOT NULL,

                                FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
                            );";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS DetalleVentas (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                VentaId INTEGER NOT NULL,
                                ProductoId INTEGER NOT NULL,
                                Cantidad INTEGER NOT NULL,
                                PrecioUnitario REAL NOT NULL,
                                Subtotal REAL NOT NULL,

                                FOREIGN KEY (VentaId) REFERENCES Ventas(Id),
                                FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
                            );";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Inventario (
                                ProductoId INTEGER PRIMARY KEY,
                                StockActual INTEGER NOT NULL DEFAULT 0,
                                StockMinimo INTEGER NOT NULL DEFAULT 0,

                                FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
                            );";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS MovimientosInventario (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                ProductoId INTEGER NOT NULL,
                                TipoMovimiento TEXT CHECK(TipoMovimiento IN ('ENTRADA','SALIDA')),
                                Cantidad INTEGER NOT NULL,
                                Fecha TEXT NOT NULL,
                                Referencia TEXT,

                                FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
                            );";
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        // =================== MÉTODOS GENERALES ===================
        public void EjecutarComando(string sql, params (string, object)[] parametros)
        {
            using var conn = new SqliteConnection($"Data Source={connectionDB}");
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            foreach (var (nombre, valor) in parametros)
            {
                cmd.Parameters.AddWithValue(nombre, valor);
            }

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool EjecutarComandoConResultado(string sql, params (string, object)[] parametros)
        {
            using var conn = new SqliteConnection($"Data Source={connectionDB}");
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            foreach (var (nombre, valor) in parametros)
            {
                cmd.Parameters.AddWithValue(nombre, valor);
            }

            int filasAfectadas = cmd.ExecuteNonQuery();
            conn.Close();

            return filasAfectadas > 0; // true si afectó filas, false si no
        }

        public DataTable EjecutarConsulta(string sql)
        {
            using var conn = new SqliteConnection($"Data Source={connectionDB}");
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            using var reader = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);

            conn.Close();
            return dt;
        }

    }
}