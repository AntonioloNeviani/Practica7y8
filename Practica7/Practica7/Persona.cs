using System;
using MySql.Data.MySqlClient;
namespace Practica7
{
	public class Persona : MySQL
	{
		public Persona ()
		{
		}
		
		public void mostrarTodos(){
			Console.Clear();
			Console.WriteLine("\t*Lista Completa\n");
			this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.querySelect(), 
			                                          myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
	        while (myReader.Read()){
	            string id = myReader["id"].ToString();
	            string codigo = myReader["codigo"].ToString();
	            string nombre = myReader["nombre"].ToString();
				string telefono = myReader["telefono"].ToString();
				string email = myReader["email"].ToString();
	            Console.WriteLine("ID: " + id +
				                  "\n\t Código: " + codigo + 
				                  "\t\t Telefono: " + telefono +
				                  "\n\t Nombre: " + nombre +
				                  "\t Email: " + email+ "" +
				                  "\n_________________________________________________________");
	       }
			
            myReader.Close();
			myReader = null;
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
			Console.WriteLine("\nListo...");
			Console.ReadKey(true);
		}
		
		public void insertarRegistroNuevo(){
			string codigo, nombre, telefono, email;
			Console.Clear();
			Console.WriteLine("\t*Registro Nuevo\n");
			Console.WriteLine("Digite el Código: ");
			codigo = Console.ReadLine();
			Console.WriteLine("Digite el Nombre: ");
			nombre = Console.ReadLine();
			Console.WriteLine("Digite el Telefono: ");
			telefono = Console.ReadLine();
			Console.WriteLine("Digite el Correo Electronico: ");
			email = Console.ReadLine();
			this.abrirConexion();
			string sql = "INSERT INTO `persona` (`codigo`, `nombre`, `telefono`, `email`) VALUES ('" + codigo + "', '" + nombre + "', '" + telefono + "', '" + email + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
			Console.WriteLine("\nListo se a agregado el Registro Nuevo");
			Console.ReadKey(true);
		}
		
			public void mostrarID(string id){
			Console.Clear();
			this.abrirConexion();
				MySqlCommand myCommand = new MySqlCommand("SELECT * FROM `persona` WHERE (`id`='" + id + "')", 
				                                          myConnection);
	            MySqlDataReader myReader = myCommand.ExecuteReader();	
				myReader.Read();
		        string codigo = myReader["codigo"].ToString();
		        string nombre = myReader["nombre"].ToString();
				string telefono = myReader["telefono"].ToString();
				string email = myReader["email"].ToString();
	            Console.Clear();
				Console.WriteLine("ID: " + id +
				                  "\n\t Código: " + codigo + 
				                  "\t\t Telefono: " + telefono +
				                  "\n\t Nombre: " + nombre +
				                  "\t Email: " + email+ "" +
				                  "\n_________________________________________________________");
	            myReader.Close();
				myReader = null;
	            myCommand.Dispose();
				myCommand = null;
				this.cerrarConexion();
		}
		
		public void editarCodigoRegistro(){
			string id, codigo, g;
			Console.WriteLine("Introduce el ID: ");
			id = Console.ReadLine();
			try 
				{
				this.mostrarID(id);
				Console.WriteLine("\n¿Estas seguro en editar el Código? \n si-1 no-2");
				g = Console.ReadLine();
				if(g == "1"){
					Console.WriteLine("Introduce el Nuevo Código: ");
					codigo = Console.ReadLine();
					this.abrirConexion();
					string sql = "UPDATE `persona` SET `codigo`='" + codigo + "' WHERE (`id`='" + id + "')";
					this.ejecutarComando(sql);
					this.cerrarConexion();
					Console.WriteLine("\nEl Código Fue editado con exito");
					Console.ReadKey(true);
				}
			}catch(Exception){
				Console.WriteLine("\nNo Existe el reguistro con el ID: "+id);
				Console.ReadKey(true);
			}
		}
		
		public void editarNombreRegistro(){
			string id, nombre, g;
			Console.WriteLine("Introduce el ID: ");
			id = Console.ReadLine();
			try 
				{
				this.mostrarID(id);
				Console.WriteLine("\n¿Estas seguro en editar el Nombre? \n si-1 no-2");
				g = Console.ReadLine();
				if(g == "1"){
					Console.WriteLine("Introduce el Nuevo Nombre: ");
					nombre = Console.ReadLine();
					this.abrirConexion();
					string sql = "UPDATE `persona` SET `nombre`='" + nombre + "' WHERE (`id`='" + id + "')";
					this.ejecutarComando(sql);
					this.cerrarConexion();
					Console.WriteLine("\nEl Nombre Fue editado con exito");
					Console.ReadKey(true);
				}
			}catch(Exception){
				Console.WriteLine("\nNo Existe el reguistro con el ID: "+id);
				Console.ReadKey(true);
			}
		}
		
			public void editarTelefonoRegistro(){
			string id, telefono, g;
			Console.WriteLine("Introduce el ID: ");
			id = Console.ReadLine();
			try 
				{
				this.mostrarID(id);
				Console.WriteLine("\n¿Estas seguro en editar el Telefono? \n si-1 no-2");
				g = Console.ReadLine();
				if(g == "1"){
					Console.WriteLine("Introduce el Nuevo Telefono: ");
					telefono = Console.ReadLine();
					this.abrirConexion();
					string sql = "UPDATE `persona` SET `telefono`='" + telefono + "' WHERE (`id`='" + id + "')";
					this.ejecutarComando(sql);
					this.cerrarConexion();
					Console.WriteLine("\nEl Telefono Fue editado con exito");
					Console.ReadKey(true);
				}
			}catch(Exception){
				Console.WriteLine("\nNo Existe el reguistro con el ID: "+id);
				Console.ReadKey(true);
			}
		}
		
			public void editarEmailRegistro(){
			string id, email, g;
			Console.WriteLine("Introduce el ID: ");
			id = Console.ReadLine();
			try 
				{
				this.mostrarID(id);
				Console.WriteLine("\n¿Estas seguro en editar el Telefono? \n si-1 no-2");
				g = Console.ReadLine();
				if(g == "1"){
					Console.WriteLine("Introduce el Nuevo Correo Electronico: ");
					email = Console.ReadLine();
					this.abrirConexion();
					string sql = "UPDATE `persona` SET `email`='" + email + "' WHERE (`id`='" + id + "')";
					this.ejecutarComando(sql);
					this.cerrarConexion();
					Console.WriteLine("\nEl Correo Electronico Fue editado con exito");
					Console.ReadKey(true);
				}
			}catch(Exception){
				Console.WriteLine("\nNo Existe el reguistro con el ID: "+id);
				Console.ReadKey(true);
			}
		}
		
			public void editarTodoRegistro(){
			string id, codigo, nombre, telefono, email, g;
			Console.WriteLine("Introduce el ID: ");
			id = Console.ReadLine();
			try 
				{
				this.mostrarID(id);
				Console.WriteLine("\n¿Estas seguro en editar el Código? \n si-1 no-2");
				g = Console.ReadLine();
				if(g == "1"){
					Console.WriteLine("Introduce el Nuevo Código: ");
					codigo = Console.ReadLine();
					Console.WriteLine("Introduce el Nuevo Nombre: ");
					nombre = Console.ReadLine();
					Console.WriteLine("Introduce el Nuevo Telefono: ");
					telefono = Console.ReadLine();
					Console.WriteLine("Introduce el Nuevo Correo Electronico: ");
					email = Console.ReadLine();
					this.abrirConexion();
					string sql = "UPDATE `persona` SET `codigo`='" + codigo + "', `nombre`='" + nombre + "', `telefono`='" + telefono + "', `email`='" + email + "' WHERE (`id`='" + id + "')";
					this.ejecutarComando(sql);
					this.cerrarConexion();
					Console.WriteLine("\nEl Reguistro Fue editado con exito");
					Console.ReadKey(true);
				}
			}catch(Exception){
				Console.WriteLine("\nNo Existe el reguistro con el ID: "+id);
				Console.ReadKey(true);
			}
		}

		
		public void eliminarRegistroPorId(){
			string id, g;
			Console.WriteLine("Introduce el ID: ");
			id = Console.ReadLine();
			try 
				{
				this.mostrarID(id);
				Console.WriteLine("\n¿Esta seguro que desea Eliminar el reguistro? \n si-1 no-2");
				g = Console.ReadLine();
				if(g == "1"){
					this.abrirConexion();
					string sql = "DELETE FROM `persona` WHERE (`id`='" + id + "')";
					this.ejecutarComando(sql);
					this.cerrarConexion();
					Console.WriteLine("\nEl Reguistro Fue Eliminado con exito");
					Console.ReadKey(true);
				}
			}catch(Exception){
				Console.WriteLine("\nNo Existe el reguistro con el ID: "+id);
				Console.ReadKey(true);
			}
		}
		private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}
		
		private string querySelect(){
			return "SELECT * " +
	           	"FROM persona";
		}
	}
}


