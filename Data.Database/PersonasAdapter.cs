using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
   public class PersonasAdapter: Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.TipoPersona = (Persona.TiposPersonas)(int)drPersonas["tipo_persona"];
                    per.Plan = new PlanAdapter().GetOne((int)drPersonas["id_plan"]);
                    // Arreglado arriba
                    //per.IDPlan = (int)drPersonas["id_plan"];
                    // Verifico si los datos son nulos
                    if (String.IsNullOrEmpty(drPersonas["direccion"].ToString()))
                    {
                        per.Direccion = "No posee";
                    }
                    else
                    {
                        per.Direccion = (string)drPersonas["direccion"];
                    }

                    if (String.IsNullOrEmpty(drPersonas["email"].ToString()))
                    {
                        per.Email = "No posee";
                    }
                    else
                    {
                        per.Email = (string)drPersonas["email"];
                    }

                    if (String.IsNullOrEmpty(drPersonas["telefono"].ToString()))
                    {
                        per.Telefono = "No posee";
                    }
                    else
                    {
                        per.Telefono = (string)drPersonas["telefono"];
                    }

                    if (String.IsNullOrEmpty(drPersonas["legajo"].ToString()))
                    {
                        per.Legajo = 0;
                    }
                    else
                    {
                        per.Legajo = (int)drPersonas["legajo"];
                    }
                    personas.Add(per);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de Personas", Ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return personas;
        }

        public List<Persona> GetAllTipo(Persona.TiposPersonas tipo)
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where tipo_persona = @tipo_persona", sqlConn);

                cmdPersonas.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)tipo;

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Persona.TiposPersonas)(int)drPersonas["tipo_persona"];
                    per.Plan.ID = (int)drPersonas["id_plan"];
                    //Corregido arriba
                    //per.IDPlan = (int)drPersonas["id_plan"];

                    personas.Add(per);
                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Erro al recuperar lista de Personas por Tipo", Ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return personas;
        }


        ////public int GetOneByDesc(string descripcion)

        ////{
        ////    int Id;
        ////    try
        ////    {
        ////        this.OpenConnection();

        ////        SqlCommand cmdMateria = new SqlCommand("select id_materia from MATERIAS where desc_materia = @descripcion ", sqlConn);
        ////        cmdMateria.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = descripcion;

        ////        Id = Convert.ToInt32(cmdMateria.ExecuteScalar());




        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        Exception ExcepcionManejada =
        ////            new Exception("Erro al recuperar lista de Materias", Ex);

        ////        throw ExcepcionManejada;
        ////    }
        ////    finally
        ////    {
        ////        this.CloseConnection();
        ////    }

        ////    return Id;

        ////}


        public Business.Entities.Persona GetOne(int ID)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.TipoPersona = (Persona.TiposPersonas)(int)drPersonas["tipo_persona"];
                    per.Plan = new PlanAdapter().GetOne((int)drPersonas["id_plan"]);
                    // Corregido arriba
                    //per.IDPlan = (int)drPersonas["id_plan"];

                    if (String.IsNullOrEmpty(drPersonas["direccion"].ToString()))
                    {
                        per.Direccion = "No posee";
                    }
                    else
                    {
                        per.Direccion = (string)drPersonas["direccion"];
                    }

                    if (String.IsNullOrEmpty(drPersonas["email"].ToString()))
                    {
                        per.Email = "No posee";
                    }
                    else
                    {
                        per.Email = (string)drPersonas["email"];
                    }

                    if (String.IsNullOrEmpty(drPersonas["telefono"].ToString()))
                    {
                        per.Telefono = "No posee";
                    }
                    else
                    {
                        per.Telefono = (string)drPersonas["telefono"];
                    }

                    if (String.IsNullOrEmpty(drPersonas["legajo"].ToString()))
                    {
                        per.Legajo = 0;
                    }
                    else
                    {
                        per.Legajo = (int)drPersonas["legajo"];
                    }
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete personas where id_persona = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE personas SET nombre = @nombre, apellido = @apellido, direccion = @direccion, email = @email , telefono = @telefono, fecha_nac = @fecha_nac, legajo = @legajo, tipo_persona= @tipo_persona, id_plan = @id_plan " +
                    "WHERE id_persona = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = persona.IDPlan;

                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public int Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                // PUEDE HABER ERRORES ACA , HAY QUE REVISAR
                SqlCommand cmdSave = new SqlCommand(
                    "insert into personas(nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan)" +
                    "values (@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan)" +
                    "select @@identity",
                    sqlConn);


                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = persona.IDPlan;
                return Int32.Parse(cmdSave.ExecuteScalar().ToString());
                //persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el id desde la base de datos
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
