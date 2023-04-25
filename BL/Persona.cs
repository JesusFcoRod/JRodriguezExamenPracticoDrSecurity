using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CURP;
using CURP.Enums;

namespace BL
{
    public class Persona
    {
        public static ML.Result Add(ML.Persona persona)
        {

            ML.Result result = new ML.Result();

            try
            {
                persona.CURP = GenerarCurp(persona);

                using (DL.JRodriguezExamenPracticoDrSecurityEntities contex = new DL.JRodriguezExamenPracticoDrSecurityEntities())
                {
                    var query = contex.PersonaAdd(persona.Nombre, persona.ApellidoPaterno, persona.ApellidoMaterno, DateTime.Parse(persona.FechaNacimiento), persona.Sexo, persona.EstadoNacimiento, persona.Direccion.IdDireccion, persona.CURP);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;

        }

        public static ML.Result Update(ML.Persona persona)
        {
            ML.Result result = new ML.Result();

            try
            {
                persona.CURP = GenerarCurp(persona);

                using (DL.JRodriguezExamenPracticoDrSecurityEntities contex = new DL.JRodriguezExamenPracticoDrSecurityEntities())
                {
                    var query = contex.PersonaUpdate(persona.IdPersona, persona.Nombre, persona.ApellidoPaterno, persona.ApellidoMaterno, DateTime.Parse(persona.FechaNacimiento), persona.Sexo, persona.EstadoNacimiento, persona.Direccion.IdDireccion, persona.CURP);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else { result.Correct = false; }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;

        }

        public static ML.Result Delete(int IdPersona)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezExamenPracticoDrSecurityEntities contex = new DL.JRodriguezExamenPracticoDrSecurityEntities())
                {
                    var query = contex.PersonaDelete(IdPersona);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else { result.Correct = false; }

                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezExamenPracticoDrSecurityEntities contex = new DL.JRodriguezExamenPracticoDrSecurityEntities())
                {
                    var query = contex.PersonaGetAll().ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Persona persona = new ML.Persona();

                            persona.IdPersona = item.IdPersona;
                            persona.NombreCompleto = item.Nombre + " " +
                                                     item.ApellidoPaterno + " " +
                                                     item.ApellidoMaterno + " ";

                            persona.FechaNacimiento = item.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                            persona.Sexo = item.Sexo;
                            persona.EstadoNacimiento = item.EstadoNacimiento;

                            persona.Direccion = new ML.Direccion();
                            persona.Direccion.IdDireccion = item.IdDireccion.Value;

                            persona.DireccionCompleta = item.EstadoCiudad + " " +
                                                        item.DelegacionMunicipio + " " +
                                                        item.Colonia + " " +
                                                        item.NumeroExterior;

                            persona.CURP = item.CURP;
                            result.Objects.Add(persona);
                            result.Correct = true;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetById(int IdPersona)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JRodriguezExamenPracticoDrSecurityEntities contex = new DL.JRodriguezExamenPracticoDrSecurityEntities())
                {
                    var query = contex.PersonaFetById(IdPersona).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Persona persona = new ML.Persona();
                        persona.IdPersona = query.IdPersona;
                        persona.Nombre = query.Nombre;
                        persona.ApellidoPaterno = query.ApellidoPaterno;
                        persona.ApellidoMaterno = query.ApellidoMaterno;
                        persona.FechaNacimiento = query.FechaNacimiento.Value.ToString("yyyy-MM-dd");
                        persona.Sexo = query.Sexo;
                        persona.EstadoNacimiento = query.EstadoNacimiento;
                        persona.CURP = query.CURP;

                        persona.Direccion = new ML.Direccion();
                        persona.Direccion.IdDireccion = query.IdDireccion.Value;

                        result.Object = persona;
                        result.Correct = true;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static string GenerarCurp(ML.Persona persona)
        {
            try
            {
                Estado result;
                Enum.TryParse(persona.EstadoNacimiento, out result); //Extraer ocincidencia de cadena en el enum Estados

                var Sex = Sexo.Mujer; //inicializamos el sexo = Mujer
                bool H = persona.Sexo.Contains("Hombre");//Si existe la cadena hombre en la variable sexo
                
                if (H == true)
                {
                    Sex = Sexo.Hombre;
                }
                string CURP = Curp.Generar(persona.Nombre,
                                           persona.ApellidoPaterno,
                                           persona.ApellidoMaterno,
                                           Sex,
                                           DateTime.Parse(persona.FechaNacimiento),
                                           result);//result es el estado donde se hayo coincidencia
                if (CURP != null)//Si s egenero el CURP lo asiganmos al objeto persona
                {
                    persona.CURP = CURP;
                }
            }
            catch (Exception ex)
            {

            }
            return persona.CURP;
        }

    }
}
