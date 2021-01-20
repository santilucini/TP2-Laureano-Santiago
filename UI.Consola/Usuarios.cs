using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        #region Constructores
        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }
        #endregion

        #region Metodos


        public void Menu()
        {

            string sel1 = "1";

            while (sel1 != "6")
            {
                Console.Clear();
                Console.WriteLine("\n╔ Seleccione Una Opcion: ");
                Console.WriteLine("╠═══════════════════════");
                Console.WriteLine("║ 1 - Listado General \n" +
                                  "║ 2 - Consulta        \n" +
                                  "║ 3 - Agregar         \n" +
                                  "║ 4 - Modificar       \n" +
                                  "║ 5 - Eliminar        \n" +
                                  "║                     \n" +
                                  "╚ 6 - Salir");

                switch (sel1 = Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Entro en Case 1");
                        ListadoGeneral();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Entro en Case 2");
                        Consultar();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Entro en Case 3");
                        Agregar();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Entro en Case 4");
                        Modificar();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("Entro en Case 5");
                        Eliminar();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("Entro en Case 6");
                        break;


                    default:
                        Console.Clear();
                        Console.WriteLine("\n|X| Seleccion Incorrecta Intenta Nuevamente |X|");
                        break;
                }


            }



        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario user in UsuarioNegocio.GetAll())
            {
                MostrarDatos(user);
            }
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            
        }

        public void MostrarDatos(Usuario user)
        {
            Console.WriteLine("╔");
            Console.WriteLine("║ Usuario : {0}", user.ID);
            Console.WriteLine("╠\t╚╗ Nombre: {0}", user.Nombre);
            Console.WriteLine("║\t ╠ Apellido: {0}", user.Apellido);
            Console.WriteLine("║\t ╠ Nombre de Usuario: {0}", user.NombreUsuario);
            Console.WriteLine("║\t ╠ Clave: {0}", user.Clave);
            Console.WriteLine("║\t ╠ Email: {0}", user.Email);
            Console.WriteLine("╚\t ╚ Habilitado: {0}", user.Habilitado);
            


        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("╔Ingrese el ID del Usuario a Consultar:");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
                
            }
            #region ExcepcionesConsultar
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("|X| La ID Ingresada debe ser un Numero Entero |X|");
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine();
                Console.WriteLine("|X| No Existe Usuario con Esa ID |X|");
            }
            catch (Exception e)
             {
                 Console.WriteLine();
                 Console.WriteLine("|X| Error Desconocido , Ni siquiera deberias ver esto |X|");
             }

            finally
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

            #endregion

        }

        public void Modificar()
        {
            try
            {
                string sel1 = "T";

                Console.Clear();
                Console.Write("╔Ingrese el ID del Usuario a Consultar:");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);

                while (sel1 != "S")
                {
                    Console.Clear();
                    Console.WriteLine("╠ Usuario Seleccionado: {0}", usuario.ID);               
                    this.MostrarDatos(usuario);               
                    Console.WriteLine("╠ Seleccion que desea modificar:");              
                    Console.WriteLine(
                    "╠ T / otro - Todos los Datos \n" +
                    "╠ N - Nombre \n" +
                    "╠ A - Apellido \n" +
                    "╠ NU - Nombre Usuario \n" +
                    "╠ C - Clave \n" +
                    "╠ E - Email \n" +
                    "╠ H - Habilitacion \n" +
                    "╚ S - Salir");     
                    
                    switch (sel1 = Console.ReadLine().ToUpper())
               
                    {
                    case "N":
                            Console.Clear();
                            ModificarNombre(usuario);
                            break;

                    case "A":
                            Console.Clear();
                            ModificarApellido(usuario);
                            break;

                    case "NU":
                            Console.Clear();
                            ModificarNombreUsuario(usuario);
                            break;

                    case "C":
                            Console.Clear();
                            ModificarClave(usuario);
                            break;

                    case "E":
                            Console.Clear();
                            ModificarEmail(usuario);

                            break;

                    case "H":
                            Console.Clear();
                            ModificarHabilitacion(usuario);
                            UsuarioNegocio.Save(usuario);
                            break;

                    case "S":
                        break;

                    default:
                            
                            Console.Clear();
                            ModificarNombre(usuario);
                            ModificarApellido(usuario);
                            ModificarNombreUsuario(usuario);
                            ModificarClave(usuario);
                            ModificarEmail(usuario);
                            ModificarHabilitacion(usuario);
                            break;
             
                    }
               
                }

                UsuarioNegocio.Save(usuario);

            }
            #region ExcepcionesModificar
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("|X| La ID Ingresada debe ser un Numero Entero |X|");
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine();
                Console.WriteLine("|X| No Existe Usuario con Esa ID |X|");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("|X| Error Desconocido , Ni siquiera deberias ver esto |X|");
            }

            finally
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
            #endregion

        }

        #region MetodosDeModificar

        public void ModificarNombre(Usuario usuario) 
        {
            Console.WriteLine("╔ Nombre Actual: {0}", usuario.Nombre);
            Console.WriteLine("║ ");
            Console.Write("╚ Nombre Nuevo: ");
            usuario.Nombre = Console.ReadLine();
        }

        public void ModificarApellido(Usuario usuario)
        {
            Console.WriteLine("╔ Apellido Actual: {0}", usuario.Apellido);
            Console.WriteLine("║ ");
            Console.Write("╚ Apellido Nuevo: ");
            usuario.Apellido = Console.ReadLine();
        }

        public void ModificarNombreUsuario(Usuario usuario)
        {
            Console.WriteLine("╔ Nombre de Usuario Actual: {0}", usuario.NombreUsuario);
            Console.WriteLine("║ ");
            Console.Write("╚ Nombre de Usuario Nuevo: ");
            usuario.NombreUsuario = Console.ReadLine();
        }

        public void ModificarClave(Usuario usuario)
        {
            Console.WriteLine("╔ Clave Actual: {0}", usuario.Clave);
            Console.WriteLine("║ ");
            Console.Write("╚ Clave Nueva: ");
            usuario.Clave = Console.ReadLine();
        }

        public void ModificarEmail(Usuario usuario)
        {
            Console.WriteLine("╔ Email Actual: {0}", usuario.Email);
            Console.WriteLine("║ ");
            Console.Write("╚ Email Nuevo: ");
            usuario.Email = Console.ReadLine();
        }

        public void ModificarHabilitacion(Usuario usuario)
        {
            Console.WriteLine("╔ Habilitacion Actual: {0}", usuario.Habilitado);
            Console.WriteLine("║ ");
            Console.Write("╠ Habilaticion Nueva ( 1 - SI | otro - NO )  ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            Console.WriteLine("╚ Habilitacion Nueva Seteada: {0}", usuario.Habilitado );
            Console.WriteLine("\nPresione alguna tecla para continuar...");
            Console.ReadKey();
        }

        #endregion


        public void Agregar()
        {
            Usuario usuario = new Usuario();

            Console.Clear();

            Console.WriteLine("╔");
            Console.WriteLine("║ Agregando Nuevo Usuario");
            Console.Write("╠\t╚╗ Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("║\t ╠ Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("║\t ╠ Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("║\t ╠ Clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("║\t ╠ Email: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("╚\t ╚ Habilitado: ");
            ModificarHabilitacion(usuario);
            UsuarioNegocio.Save(usuario);
            Console.WriteLine("");
            Console.WriteLine("╔══");
            Console.WriteLine("║ Se Agrego el Usuario con ID Nº" + usuario.ID);
            Console.WriteLine("╚══");
            Console.ReadKey();


        }

        public void Eliminar()
        {

            try
            {
                string sel1 = "no";

                Console.Clear();
                Console.Write("╔ Ingrese el ID del Usuario a ELIMINAR:");
                int ID = int.Parse(Console.ReadLine());
                Console.WriteLine("╚ El Usuario A Eliminar es:");
                MostrarDatos(UsuarioNegocio.GetOne(ID));
                Console.Write("\n╔ Para Confirmar escriba [ eliminar ] o [ del ]:");
                sel1 = Console.ReadLine().ToUpper(); ;
                if ( (sel1 == "ELIMINAR") || (sel1 == "DEL" ))
                {
                    UsuarioNegocio.Delete(ID);
                    Console.WriteLine("╚ Se Elimino el Usuario Con Exito");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("╚ Operacion Cancelada");
                    Console.ReadKey();
                }


            }
            #region ExcepcionesEliminar
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("|X| La ID Ingresada debe ser un Numero Entero |X|");
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine();
                Console.WriteLine("|X| No Existe Usuario con Esa ID |X|");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("|X| Error Desconocido , Ni siquiera deberias ver esto |X|");
            }

            finally
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

            #endregion

        }


        #endregion




        #region Propiedades
        private Business.Logic.UsuarioLogic _UsuarioNegocio;

        public Business.Logic.UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }
        #endregion
    }
}
