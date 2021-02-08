using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select * from planes", sqlConn);

                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan pln = new Plan();

                    pln.ID = (int)drPlanes["id_plan"];
                    pln.Descripcion = (string)drPlanes["desc_plan"];
                    pln.Especialidad = new EspecialidadAdapter().GetOne((int)drPlanes["id_especialidad"]);
                    planes.Add(pln);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Erro al recuperar lista de Planes", Ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }

        

        public Business.Entities.Plan GetOne(int ID)
        {
            Plan pln = new Plan();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan = @id", sqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                if (drPlanes.Read())
                {
                    pln.ID = (int)drPlanes["id_plan"];
                    pln.Descripcion = (string)drPlanes["desc_plan"];
                    pln.Especialidad = new EspecialidadAdapter().GetOne((int)drPlanes["id_especialidad"]);
                    // Arreglado arriba
                    //pln.IDEspecialidad = (int)drPlanes["id_especialidad"];
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return pln;
        }

        public int GetOneByDesc(string descripcion)

        {
            int Id;
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlan = new SqlCommand("select id_plan from PLANES where desc_plan = @descripcion ", sqlConn);
                cmdPlan.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = descripcion;

                Id = Convert.ToInt32(cmdPlan.ExecuteScalar());




            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Erro al recuperar lista de Planes", Ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return Id;

        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete planes where id_plan = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


        }

        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE planes SET desc_plan = @desc_plan, id_especialidad = @id_especialidad " +
                    "WHERE id_plan = @id_plan", sqlConn);

                //SqlCommand cmdSave = new SqlCommand(
                //    "UPDATE planes SET desc_plan = @desc_plan " +
                //    "WHERE id_plan = @id_plan", sqlConn);

                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "insert into planes(desc_plan,id_especialidad)" +
                    "values (@desc_plan,@id_especialidad)" +
                    "select @@identity",
                    sqlConn);

                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;

                //plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el id desde la base de datos
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;


        }
    }
}
