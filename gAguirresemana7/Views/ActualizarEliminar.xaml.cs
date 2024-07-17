using Newtonsoft.Json;
using System.Text;

namespace gAguirresemana7.Views;

public partial class ActualizarEliminar : ContentPage
{
    private const string Url = "http://26.171.203.115/semana6/estudiantews.php";
    private readonly HttpClient cliente = new HttpClient();
    public ActualizarEliminar(Modelos.Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();
    }

    private  async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        var datos = new
        {
            codigo = txtCodigo.Text,
            nombre = txtNombre.Text,
            apellido = txtApellido.Text,
            edad = txtEdad.Text
        };
        var json = JsonConvert.SerializeObject(datos);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await cliente.PutAsync(Url, content);
        string respuesta = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Éxito", "Los datos se actualizaron correctamente.", "Aceptar");
            Navigation.PushAsync(new Estudiante());
        }
        else
        {
            await DisplayAlert("Error", "Hubo un problema al intentar actualizar los datos.", "Aceptar");
        }
    }

    private async void btnElimianr_Clicked(object sender, EventArgs e)
    {
        var codigo = txtCodigo.Text;
        var response = await cliente.DeleteAsync($"{Url}?codigo={codigo}");
        string respuesta = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Éxito", "El estudiante se eliminó correctamente.", "Aceptar");
            Navigation.PushAsync(new Estudiante());
        }
        else
        {
            await DisplayAlert("Error", "Hubo un problema al intentar eliminar al estudiante.", "Aceptar");
        }
    }
}
