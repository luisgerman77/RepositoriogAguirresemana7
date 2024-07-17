using System.Collections.ObjectModel;
using System;
using Newtonsoft.Json;


namespace gAguirresemana7.Views;

public partial class Estudiante : ContentPage
{
    private const string Url = "http://26.171.203.115/semana6/estudiantews.php";

    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Modelos.Estudiante> est;

    public Estudiante()
	{
		InitializeComponent();
        visualizar();
	}
    public async void visualizar()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Modelos.Estudiante> visualizar = JsonConvert.DeserializeObject<List<Modelos.Estudiante>>(content);
        est = new ObservableCollection<Modelos.Estudiante>(visualizar);
        lisEstudiantes.ItemsSource = est;
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vAgregar());
    }

    private void lisEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (Modelos.Estudiante)e.SelectedItem;
        Navigation.PushAsync(new ActualizarEliminar(objEstudiante));
    }
}