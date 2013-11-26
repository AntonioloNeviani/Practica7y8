using System;

namespace Practica7
{
	public class Menu
	{
		public Menu ()
		{
		}
		public void mostrarMenu(){
			Console.Clear();
			Console.WriteLine ("\t*Menu Principal\n" +
				"1.- Mostrar todo\n" +
				"2.- Agregar Nuevo Registro\n" +
				"3.- Editar Registro\n" +
				"4.- Eliminar Registro\n" +
				"5.- Salir");
		}
		public void menuEditar(){
			Console.Clear();
			Console.WriteLine ("\t*Editar Registro\n" +
				"1.- Editar Código\n" +
				"2.- Editar Nombre\n" +
				"3.- Editar Telefono\n" +
				"4.- Editar Correo Electronico\n" +
				"5.- Editar Todo el Registro\n" +
			    "6.- Regresar");
		}
		public void swichPrincipal(){
			Persona persona = new Persona();
			string opc;
			do{
				mostrarMenu();
				opc = Console.ReadLine();
				switch(opc){
					case "1":
						persona.mostrarTodos();
						break;
					case "2":
						persona.insertarRegistroNuevo();
						break;
					case "3":
						swichEditar();
						break;
					case "4":
						persona.eliminarRegistroPorId();
						break;
					case "5":
						Console.ResetColor();
						Console.Clear();
						Console.WriteLine("Adios :)\n");
						Console.Write("Press any key to continue...");
						Console.ReadKey(true);
						break;
					default:
						Console.WriteLine("Opcion incorrecta :(");
						Console.ReadKey(true);
						break;
				}
			}while(opc != "5");
		}
		public void swichEditar(){
			Persona persona = new Persona();
			string ops;
			do{
				menuEditar();
				ops = Console.ReadLine();
				switch(ops){
					case "1":
						persona.editarCodigoRegistro();
						break;
					case "2":
						persona.editarNombreRegistro();
						break;
					case"3":
						persona.editarTelefonoRegistro();
						break;
					case"4":
						persona.editarEmailRegistro();
						break;
					case"5":
						persona.editarTodoRegistro();
						break;
					case"6":
						break;
					default:
						Console.Clear();
						Console.WriteLine("Opcion incorrecta");
						Console.ReadKey(true);
						break;
				}
			}while(ops != "6");
	}
}
}
