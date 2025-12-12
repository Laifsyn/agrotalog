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
                    Precio REAL,
                    Stock INTEGER,
                    Unidad TEXT
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
                    Contacto TEXT,
                    Telefono TEXT,
                    Email TEXT,
                    Direccion TEXT
                );";
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        // =================== CLIENTES ===================
        public void AgregarCliente(string nombre, string direccion, string telefono, string email, string tipoCliente)
        {
            string sql = "INSERT INTO Clientes (Nombre, Direccion, Telefono, Email, TipoCliente) VALUES ($nombre,$direccion,$telefono,$email,$tipoCliente)";
            EjecutarComando(sql,
                ("$nombre", nombre),
                ("$direccion", direccion),
                ("$telefono", telefono),
                ("$email", email),
                ("$tipoCliente", tipoCliente));
        }

        public DataTable MostrarClientes()
        {
            string sql = "SELECT * FROM Clientes";
            return EjecutarConsulta(sql);
        }

        public bool ActualizarCliente(int id, string nombre, string direccion, string telefono, string email, string tipoCliente)
        {
            string sql = @"
                UPDATE Clientes
                SET Nombre=$nombre, Direccion=$direccion, Telefono=$telefono, Email=$email, TipoCliente=$tipoCliente
                WHERE Id=$id";
            return EjecutarComandoConResultado(sql,
                ("$nombre", nombre),
                ("$direccion", direccion),
                ("$telefono", telefono),
                ("$email", email),
                ("$tipoCliente", tipoCliente),
                ("$id", id));
        }

        public bool EliminarCliente(int id)
        {
            string sql = "DELETE FROM Clientes WHERE Id=$id";
            return EjecutarComandoConResultado(sql, ("$id", id));
        }

        // =================== PROVEEDORES ===================
        public void AgregarProveedor(string nombre, string contacto, string telefono, string email, string direccion)
        {
            string sql = "INSERT INTO Proveedores (Nombre, Contacto, Telefono, Email, Direccion) VALUES ($nombre,$contacto,$telefono,$email,$direccion)";
            EjecutarComando(sql,
                ("$nombre", nombre),
                ("$contacto", contacto),
                ("$telefono", telefono),
                ("$email", email),
                ("$direccion", direccion));
        }

        public DataTable MostrarProveedores()
        {
            string sql = "SELECT * FROM Proveedores";
            return EjecutarConsulta(sql);
        }

        public bool ActualizarProveedor(int id, string nombre, string contacto, string telefono, string email, string direccion)
        {
            string sql = @"
                UPDATE Proveedores
                SET Nombre=$nombre, Contacto=$contacto, Telefono=$telefono, Email=$email, Direccion=$direccion
                WHERE Id=$id";
            return EjecutarComandoConResultado(sql,
                ("$nombre", nombre),
                ("$contacto", contacto),
                ("$telefono", telefono),
                ("$email", email),
                ("$direccion", direccion),
                ("$id", id));
        }

        public bool EliminarProveedor(int id)
        {
            string sql = "DELETE FROM Proveedores WHERE Id=$id";
            return EjecutarComandoConResultado(sql, ("$id", id));
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