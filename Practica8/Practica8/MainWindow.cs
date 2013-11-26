using System;
using Gtk;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		listaFull();
		node();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected MySqlConnection myConnection;
	protected void abrirConexion(){
		string connectionString =
      		"Server=localhost;" +
          	"Database=agenda;" +
          	"User ID=root;" +
          	"Password=jorge12345;" +
          	"Pooling=false;";
       this.myConnection = new MySqlConnection(connectionString);
       this.myConnection.Open();
	}
	protected void cerrarConexion(){
		this.myConnection.Close(); 
		this.myConnection = null;
	}
	private int ejecutarComando(string sql){
		MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
		int afectadas = myCommand.ExecuteNonQuery();
		myCommand.Dispose();
		myCommand = null;
		return afectadas;
	}
	private void listaFull(){
		ListStore TipoDeListado;
		TipoDeListado = new ListStore (typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
		nodeview1.Model = TipoDeListado;
		
		this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(
								"SELECT * FROM `persona`", myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
	        while (myReader.Read()){
	            string id = myReader["id"].ToString();
	            string codigo = myReader["codigo"].ToString();
	            string nombre = myReader["nombre"].ToString();
				string telefono = myReader["telefono"].ToString();
				string email = myReader["email"].ToString();
	            TipoDeListado.AppendValues(id, codigo, nombre, telefono, email);
	       }
			
            myReader.Close();
			myReader = null;
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();

	}
	private void node(){
		nodeview1.AppendColumn("ID", new CellRendererText(), "text", 0);
		nodeview1.AppendColumn("Código", new CellRendererText(), "text", 1); 
		nodeview1.AppendColumn("Nombre", new CellRendererText(), "text", 2);
		nodeview1.AppendColumn("Telefono", new CellRendererText(), "text", 3); 
		nodeview1.AppendColumn("Correo Electronico", new CellRendererText(), "text", 4);
		nodeview1.EnableGridLines = TreeViewGridLines.Horizontal;
		nodeview2.AppendColumn("ID", new CellRendererText(), "text", 0);
		nodeview2.AppendColumn("Código", new CellRendererText(), "text", 1); 
		nodeview2.AppendColumn("Nombre", new CellRendererText(), "text", 2);
		nodeview2.AppendColumn("Telefono", new CellRendererText(), "text", 3); 
		nodeview2.AppendColumn("Correo Electronico", new CellRendererText(), "text", 4);
		nodeview2.EnableGridLines = TreeViewGridLines.Horizontal;
		nodeview3.AppendColumn("ID", new CellRendererText(), "text", 0);
		nodeview3.AppendColumn("Código", new CellRendererText(), "text", 1); 
		nodeview3.AppendColumn("Nombre", new CellRendererText(), "text", 2);
		nodeview3.AppendColumn("Telefono", new CellRendererText(), "text", 3); 
		nodeview3.AppendColumn("Correo Electronico", new CellRendererText(), "text", 4);
		nodeview3.EnableGridLines = TreeViewGridLines.Horizontal;
		nodeview4.AppendColumn("ID", new CellRendererText(), "text", 0);
		nodeview4.AppendColumn("Código", new CellRendererText(), "text", 1); 
		nodeview4.AppendColumn("Nombre", new CellRendererText(), "text", 2);
		nodeview4.AppendColumn("Telefono", new CellRendererText(), "text", 3); 
		nodeview4.AppendColumn("Correo Electronico", new CellRendererText(), "text", 4);
		nodeview4.EnableGridLines = TreeViewGridLines.Horizontal;
		ListStore TipoDeListado;
		TipoDeListado = new ListStore (typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
		nodeview2.Model = TipoDeListado;
		nodeview3.Model = TipoDeListado;
		nodeview4.Model = TipoDeListado;

	}
	protected void OnActualizarListaClicked (object sender, System.EventArgs e)
	{
		listaFull();
	}

	protected void OnGuardarClicked (object sender, System.EventArgs e)
	{
		string codigo, nombre, telefono, email;
		ListStore TipoDeListado;
		TipoDeListado = new ListStore (typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
		nodeview2.Model = TipoDeListado;
		try 
			{
			codigo = codigoGtxt.Text;
			nombre = nomGtxt.Text;
			telefono = telGtxt.Text;
			email = emailGtxt.Text;
			
			if(codigo == "" || nombre == "" || telefono == "" || email == ""){
							MessageDialog md = new MessageDialog (this, DialogFlags.Modal, 
		    	                                  MessageType.Info, 
		        	                              ButtonsType.Ok, 
		            	                          "Tus campos estan vasios");
												  md.Run ();md.Destroy ();
				
			}else{
			this.abrirConexion();
			string sql = "INSERT INTO `persona` (`codigo`, `nombre`, `telefono`, `email`) VALUES ('" + codigo + "', '" + nombre + "', '" + telefono + "', '" + email + "')";
			this.ejecutarComando(sql);
	        
			MySqlCommand myCommand = new MySqlCommand("SELECT * FROM `persona` WHERE (`codigo`='" + codigo + "')", 
				                                          myConnection);
			MySqlDataReader myReader = myCommand.ExecuteReader();	
			myReader.Read();
			string id = myReader["id"].ToString();
			TipoDeListado.AppendValues(id, codigo, nombre, telefono, email);
			
			this.cerrarConexion();
			MessageDialog md = new MessageDialog (this, DialogFlags.Modal, 
		    	                                  MessageType.Info, 
		        	                              ButtonsType.Ok, 
		            	                          "Sea guardado exitosamente");
												  md.Run ();md.Destroy ();
				listaFull();
			}
		}catch(Exception h)
			{
				MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.None,"Exception: " + h.Message);md.Show();
			}
	}

	protected void OnCargarClicked (object sender, System.EventArgs e)
	{
			try 
			{
			this.abrirConexion();
			string id;
			ListStore TipoDeListado;
			TipoDeListado = new ListStore (typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
			nodeview3.Model = TipoDeListado;
			id = idtxt.Text;
            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM `persona` WHERE (`id`='" + id + "')", 
			                                          myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
	        while (myReader.Read()){
	            string codigo = myReader["codigo"].ToString();
	            string nombre = myReader["nombre"].ToString();
				string telefono = myReader["telefono"].ToString();
				string email = myReader["email"].ToString();
				codigotxt.Text = codigo.ToString();
				nombretxt.Text = nombre.ToString();
				telefonotxt.Text = telefono.ToString();
				emailtxt.Text = email.ToString();
				TipoDeListado.AppendValues(id, codigo, nombre, telefono, email);
			if(id == "NULL"){
				
					MessageDialog md = new MessageDialog (this, DialogFlags.Modal, 
		    	                                  MessageType.Info, 
		        	                              ButtonsType.Ok, 
		            	                          "No Existe El ID");
												  md.Run ();md.Destroy ();
			}
	       }
			
            myReader.Close();
			myReader = null;
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
		}catch(Exception h)
			{
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal, 
		    	                                  MessageType.Info, 
		        	                              ButtonsType.Ok, 
		            	                          "Has echo algo mal\n Exception: "+h);
												  md.Run ();md.Destroy ();
			}
	}

	protected void OnActualizarClicked (object sender, System.EventArgs e)
	{
		string id, codigo, nombre, telefono, email;
		id = idtxt.Text;
		codigo = codigotxt.Text;
		nombre = nombretxt.Text;
		telefono = telefonotxt.Text;
		email = emailtxt.Text;
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal, 
		                                      MessageType.Question, 
		                                      ButtonsType.OkCancel, 
		                                      "¿Real mente Desea actualizar el Ristro?");
		ResponseType boton = (ResponseType)md.Run ();
		md.Destroy ();
		if (boton == ResponseType.Ok) { 
			ListStore TipoDeListado;
			TipoDeListado = new ListStore (typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
			nodeview3.Model = TipoDeListado;
			
			this.abrirConexion();
			string sql = "UPDATE `persona` SET `codigo`='" + codigo + "', `nombre`='" + nombre + "', `telefono`='" + telefono + "', `email`='" + email + "' WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
			TipoDeListado.AppendValues(id, codigo, nombre, telefono, email);
			listaFull();
		}
	}

	protected void OnCargar2Clicked (object sender, System.EventArgs e)
	{
		try 
			{
			this.abrirConexion();
			string id;
			ListStore TipoDeListado;
			TipoDeListado = new ListStore (typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
			nodeview4.Model = TipoDeListado;
			id = id2txt.Text;
            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM `persona` WHERE (`id`='" + id + "')", 
			                                          myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
	        while (myReader.Read()){
	            string codigo = myReader["codigo"].ToString();
	            string nombre = myReader["nombre"].ToString();
				string telefono = myReader["telefono"].ToString();
				string email = myReader["email"].ToString();
				TipoDeListado.AppendValues(id, codigo, nombre, telefono, email);
			if(id == "NULL"){
				
					MessageDialog md = new MessageDialog (this, DialogFlags.Modal, 
		    	                                  MessageType.Info, 
		        	                              ButtonsType.Ok, 
		            	                          "No Existe El ID");
												  md.Run ();md.Destroy ();
			}
	       }
			
            myReader.Close();
			myReader = null;
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
		}catch(Exception h)
			{
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal, 
		    	                                  MessageType.Info, 
		        	                              ButtonsType.Ok, 
		            	                          "Has echo algo mal\n Exception: "+h);
												  md.Run ();md.Destroy ();
			}
	}

	protected void OnEliminarClicked (object sender, System.EventArgs e)
	{
		string id;
		id = id2txt.Text;
		MessageDialog md = new MessageDialog (this, DialogFlags.Modal, 
		                                      MessageType.Warning, 
		                                      ButtonsType.YesNo, 
		                                      "¿Realmente desea eliminar el registro con el ID "+id+"?");
		ResponseType boton = (ResponseType)md.Run ();
		md.Destroy ();
		if (boton == ResponseType.Yes) { 
			this.abrirConexion();
			string sql = "DELETE FROM `persona` WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
			listaFull();
			ListStore TipoDeListado;
			TipoDeListado = new ListStore (typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
			nodeview4.Model = TipoDeListado;
		}
		if (boton == ResponseType.No) {
			
		}
	}
}