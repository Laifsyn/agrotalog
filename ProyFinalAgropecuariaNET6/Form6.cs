using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyFinalAgropecuaria
{
    public static class ToDbEnumExtension
    {
        public static string ToDbEnum(this ProductTransactionType type)
        {
            return type switch
            {
                ProductTransactionType.Entrada => "ENTRADA",
                ProductTransactionType.Salida => "SALIDA",
            };
        }
    }

    public enum ProductTransactionType
    {
        Entrada,
        Salida
    }

    struct FormState
    {
        public int? productId = null;
        public int? cantidad = null;
        public ProductTransactionType type = ProductTransactionType.Entrada;
        public FormState()
        {

        }

        public bool IsArgsComplete()
        {
            if ((productId is null) || (cantidad is null))
            {
                return false;
            }
            return true;
        }
    }
    public partial class frmInventario : Form
    {
        BDAgro bd = new BDAgro();
        FormState state = new();

        public frmInventario()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Borrar botón??
        }

        /// <summary>
        /// Registra el cambio al producto
        /// </summary>
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            switch (this.state.type)
            {
                case ProductTransactionType.Entrada:
                    this.registrarEntrada();
                    break;
                case ProductTransactionType.Salida:
                    this.registrarSalida();
                    break;
            }
        }

        /// <summary>
        /// Registra una entrada de producto del inventario
        /// </summary>
        private void registrarEntrada()
        {
            string sql = "INSERT INTO MovimientosInventario (ProductoId, TipoMovimiento, Cantidad, Fecha) VALUES ($id, $tipo, $cantidad, $fecha)";

            if (!state.IsArgsComplete())
            {
                // Todo: return specific error
                return;
            }
            this.bd.EjecutarComando(sql,
                ("$id", state.productId!),
                ("$tipo", state.type.ToDbEnum()),
                ("$cantidad", state.cantidad!),
                ("$fecha", DateTime.Now)
            );
        }

        /// <summary>
        ///  Registra una salida del producto del inventario
        /// </summary>
        private void registrarSalida()
        {
            string sql = "INSERT INTO MovimientosInventario (ProductoId, TipoMovimiento, Cantidad, Fecha) VALUES ($id, $tipo, $cantidad, $fecha)";
            if (!state.IsArgsComplete())
            {
                // Todo: return specific error
                return;
            }
            this.bd.EjecutarComando(sql,
                ("$id", state.productId!),
                ("$tipo", state.type.ToDbEnum()),
                ("$cantidad", state.cantidad!),
                ("$fecha", DateTime.Now)
            );
        }

    }
}
