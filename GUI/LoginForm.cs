using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BEL;
using BLL;
using Services;
using Controles;
using Interfaces;
using ServiceClasses;
namespace GUI
{
    public partial class LoginForm : Form, ITraducible
    {
        List<belUsuario> ListaUsuario;
        bllUsuario bllusuario;
        string msgBlockedAccount;
        string msgWrongPassword;
        string msgNoExistAccount;
        string msgConsistentError;
        bool blockSystem = false;
        public LoginForm()
        {
            LanguageManager.InicializarServicio();
            ProfileManager.InicializarServicio();
            if (VerificacionDatos()){blockSystem = true; MessageBox.Show("error"); }
            InitializeComponent();
        }
        private bool VerificacionDatos()
        {
            List<IEntity> Lista;
            bool Error = false;
            int flag = 0;
            bllCarne carne = new bllCarne();
            bllCarneCarrito carnecarrito = new bllCarneCarrito();
            bllCarrito carrito = new bllCarrito();
            bllPedidoCompra pedidocompra = new bllPedidoCompra();
            bllPedidoCompraCarne pedidocompracarne = new bllPedidoCompraCarne();
            bllProveedor proveedor = new bllProveedor();
            bllTicket ticket = new bllTicket();
            bllCotizacion cotizacion = new bllCotizacion();
            Lista = carne.Consulta().ToList<IEntity>();
            if (VerificatorManager.CompararTotalDVH(Lista, "Carne") == false) flag++; 
            Lista = carnecarrito.ConsultaVerificacion().ToList<IEntity>();
            if (VerificatorManager.CompararTotalDVH(Lista, "CarneCarrito") == false) flag++;
            Lista = carrito.ConsultaVerificacion().ToList<IEntity>();
            if (VerificatorManager.CompararTotalDVH(Lista, "Carrito") == false) flag++;
            Lista = pedidocompra.ConsultaVerificacion().ToList<IEntity>();
            if (VerificatorManager.CompararTotalDVH(Lista, "PedidoCompra") == false) flag++;
            Lista = pedidocompracarne.ConsultaVerificacion().ToList<IEntity>();
            if (VerificatorManager.CompararTotalDVH(Lista, "PedidoCompraCarne") == false) flag++;
            Lista = proveedor.ConsultaVerificacion().ToList<IEntity>();
            if (VerificatorManager.CompararTotalDVH(Lista, "Proveedor") == false) flag++;
            Lista = ticket.ConsultaVerificacion().ToList<IEntity>();
            if (VerificatorManager.CompararTotalDVH(Lista, "Ticket") == false) flag++;
            Lista = cotizacion.ConsultaVerificacion().ToList<IEntity>();
            if (VerificatorManager.CompararTotalDVH(Lista, "Cotizacion") == false) flag++;
            if (flag > 0) Error = true;
            Lista = null;
            return Error;
        }
        private void CargarDVH()
        {
            List<IEntity> Lista;
            bllCarne carne = new bllCarne();
            bllCarneCarrito carnecarrito = new bllCarneCarrito();
            bllCarrito carrito = new bllCarrito();
            bllPedidoCompra pedidocompra = new bllPedidoCompra();
            bllPedidoCompraCarne pedidocompracarne = new bllPedidoCompraCarne();
            bllProveedor proveedor = new bllProveedor();
            bllTicket ticket = new bllTicket();
            bllCotizacion cotizacion = new bllCotizacion();
            Lista = carne.Consulta().ToList<IEntity>();
            VerificatorManager.AltaDVH(Lista, "Carne");
            VerificatorManager.ModificaciónTotalDVH("Carne");
            Lista = carnecarrito.ConsultaVerificacion().ToList<IEntity>();
            VerificatorManager.AltaDVH(Lista, "CarneCarrito");
            VerificatorManager.ModificaciónTotalDVH("CarneCarrito");
            Lista = carrito.ConsultaVerificacion().ToList<IEntity>();
            VerificatorManager.AltaDVH(Lista, "Carrito");
            VerificatorManager.ModificaciónTotalDVH("Carrito");
            Lista = pedidocompra.ConsultaVerificacion().ToList<IEntity>();
            VerificatorManager.AltaDVH(Lista, "PedidoCompra");
            VerificatorManager.ModificaciónTotalDVH("PedidoCompra");
            Lista = pedidocompracarne.ConsultaVerificacion().ToList<IEntity>();
            VerificatorManager.AltaDVH(Lista, "PedidoCompraCarne");
            VerificatorManager.ModificaciónTotalDVH("PedidoCompraCarne");
            Lista = proveedor.ConsultaVerificacion().ToList<IEntity>();
            VerificatorManager.AltaDVH(Lista, "Proveedor");
            VerificatorManager.ModificaciónTotalDVH("Proveedor");
            Lista = ticket.ConsultaVerificacion().ToList<IEntity>();
            VerificatorManager.AltaDVH(Lista, "Ticket");
            VerificatorManager.ModificaciónTotalDVH("Ticket");
            Lista = cotizacion.ConsultaVerificacion().ToList<IEntity>();
            VerificatorManager.AltaDVH(Lista, "Cotizacion");
            VerificatorManager.ModificaciónTotalDVH("Cotizacion");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ListaUsuario = bllusuario.Consulta();
            string inputUsername = textBox1.Text;
            string inputPassword = textBox2.Text;
            if (ListaUsuario.Exists(x => x.Username == inputUsername))
            {
                    belUsuario User = ListaUsuario.Find(x => x.Username == inputUsername);
                if (CryptoManager.Compare(inputPassword, User.Password) == 1 && User.Blocked == false)
                {
                    if (blockSystem)
                    {
                        if(User.Perfil.Nombre == "Admin")
                        {
                            Login();
                        }
                        else
                        {
                            MessageBox.Show(msgConsistentError);
                        }
                    }
                    else
                    {
                        Login();
                    }
                    void Login()
                    {
                        MainForm formPrincipalInstance = new MainForm();
                        SessionManager.Login(User);
                        formPrincipalInstance.SessionManager = SessionManager.GetInstance;
                        LanguageManager.Suscribir(formPrincipalInstance);
                        LogManager.AgregarLogEvento("LOGIN - Login", 1, User);
                        Idioma pIdioma = LanguageManager.Idioma((comboBoxImage1.RetornaComboBox().SelectedIndex + 1).ToString());
                        User.Idioma = pIdioma;
                        bllusuario.Modificacion(User);
                        LanguageManager.CambiarIdioma(User.Idioma.Id);
                        this.Hide();
                        formPrincipalInstance.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    if(User.Blocked == false)
                    {
                        MessageBox.Show(msgWrongPassword, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        User.Intentos -= 1;
                        LogManager.AgregarLogEvento("LOGIN - Incorrect password", 2, User);
                        if (User.Intentos == 0)
                        {
                            User.Blocked = true;
                            bllusuario.Modificacion(User);
                            MessageBox.Show(msgBlockedAccount, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LogManager.AgregarLogEvento("LOGIN - Account blocking for missed attempts",3, User);
                        }
                    }
                    else
                    {
                        MessageBox.Show(msgBlockedAccount, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LogManager.AgregarLogEvento("LOGIN - Blocked account login attempt",3, User);
                    }
                }
            }
            else{MessageBox.Show(msgNoExistAccount, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
        }
        private void FormLogIn_Load(object sender, EventArgs e)
        {
            bllusuario = new bllUsuario();
            LanguageManager.Suscribir(this);
            comboBoxImage1.RetornaComboBox().SelectedIndex = 0;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSee.Checked) { textBox2.UseSystemPasswordChar = false; }
            else { textBox2.UseSystemPasswordChar = true; }
        }

        public void Update(string pCodigoIdioma)
        {
            Idioma pIdioma = LanguageManager.ListaIdioma.Find(x => x.Id == pCodigoIdioma);
            lblUser.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblUser").Texto;
            lblPassword.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "lblPassword").Texto;
            cbSee.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "cbSee").Texto;
            btnLogin.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "btnLogin").Texto;
            msgBlockedAccount = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgBlockedAccount").Texto;
            msgWrongPassword = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgWrongPassword").Texto;
            msgNoExistAccount = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgNoExistAccount").Texto;
            msgConsistentError = pIdioma.ListaEtiquetas.Find(x => x.Tag == "msgConsistentError").Texto;
            this.Text = pIdioma.ListaEtiquetas.Find(x => x.Tag == "frmLogin").Texto;
        }
    }
}
