using System.Net;

namespace gAguirresemana7.Views;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();


            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);


            byte[] respuestaServidor = cliente.UploadValues("http://192.168.56.1/semana6/estudiantews.php", "POST", parametros);


            string respuesta = System.Text.Encoding.UTF8.GetString(respuestaServidor);


            Navigation.PushAsync(new Estudiante());


            await DisplayAlert("Éxito", "El estudiante se ha agregado correctamente.", "Ok");
        }
        catch (Exception ex)
        {

            await DisplayAlert("Error", $"Error al agregar el estudiante: {ex.Message}", "Ok");
        }
    }
}