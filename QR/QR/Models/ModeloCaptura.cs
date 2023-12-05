using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QR.Models
{
    public class ModeloCaptura
    {
        public async Task GetTheData(string url, int eventId)
        {
            try
            {
                string requestUrl = url;
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(requestUrl);

                // Utiliza HtmlAgilityPack para parsear el HTML
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response);

                // Supongamos que los datos están en la segunda y tercera fila de una tabla
                var segundaFila = htmlDoc.DocumentNode.SelectSingleNode("//table//tr[2]");
                var terceraFila = htmlDoc.DocumentNode.SelectSingleNode("//table//tr[3]");

                string numeroControl = "";
                string nombre = "";

                // Función para extraer los datos de las celdas <td> de una fila
                Action<HtmlNode> extraerDatosFila = (fila) =>
                {
                    if (segundaFila != null)
                    {
                        // Selecciona todas las celdas <td> dentro de la fila
                        var celdas = segundaFila.SelectSingleNode(".//td");

                        if (celdas != null)
                        {

                            numeroControl = celdas.InnerText.Trim().Replace("Número de Control: ", "");


                        }


                    }
                    if (terceraFila != null)
                    {
                        // Selecciona todas las celdas <td> dentro de la fila
                        var celda = terceraFila.SelectSingleNode(".//td");

                        if (celda != null)
                        {

                            nombre = celda.InnerText.Trim().Replace("Nombre: ", "");


                        }


                    }
                };

                // Extrae los datos de la segunda fila
                extraerDatosFila(segundaFila);

                // Extrae los datos de la tercera fila
                extraerDatosFila(terceraFila);
                var registroAsistencia = new RegistroAsistencia
                {
                    IdEvento = eventId,
                    HoraEntrada = DateTime.Now.TimeOfDay,
                    NombreAlumno = nombre,
                    NumeroControlAlumno = numeroControl

                };
                await App.sqLiteDb.SaveAssistanceAsync(registroAsistencia);
                await App.Current.MainPage.DisplayAlert("Registro exitoso", $"Número de Control: {numeroControl}\nNombre: {nombre}", "ok");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
