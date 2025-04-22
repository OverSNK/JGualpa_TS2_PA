namespace JGualpa_TS2_PA.Views;

public partial class vCalificaciones : ContentPage
{
	public vCalificaciones()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // Validar selección de estudiante
        if (estudiantePicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Por favor selecciona un estudiante de la lista.", "OK");
            return;
        }

        // Validar y obtener notas
        if (!ValidarNota(seguimiento1Entry.Text, out double seguimiento1, "Seguimiento 1") ||
            !ValidarNota(examen1Entry.Text, out double examen1, "Examen 1") ||
            !ValidarNota(seguimiento2Entry.Text, out double seguimiento2, "Seguimiento 2") ||
            !ValidarNota(examen2Entry.Text, out double examen2, "Examen 2"))
        {
            return;
        }

        // Calcular Notas Parciales y Nota Final
        double notaParcial1 = seguimiento1 * 0.3 + examen1 * 0.2;
        double notaParcial2 = seguimiento2 * 0.3 + examen2 * 0.2;
        double notaFinal = notaParcial1 + notaParcial2;

        // Determinar Estado
        string estado;
        if (notaFinal >= 7)
            estado = "APROBADO";
        else if (notaFinal >= 5)
            estado = "COMPLEMENTARIO";
        else
            estado = "REPROBADO";

        // Acá muestro el resultado
        string mensaje = $"Nombre: {estudiantePicker.SelectedItem}\n" +
                         $"Fecha: {fechaPicker.Date:d}\n\n" +
                         $"Nota Parcial 1: {notaParcial1:F2}\n" +
                         $"Nota Parcial 2: {notaParcial2:F2}\n" +
                         $"Nota Final: {notaFinal:F2}\n\n" +
                         $"Estado: {estado}";

        await DisplayAlert("Resultado", mensaje, "OK");
    }
    private bool ValidarNota(string texto, out double valor, string campo)
    {
        if (!double.TryParse(texto, out valor) || valor < 0 || valor > 10)
        {
            DisplayAlert("Error", $"Ingrese una nota válida entre 0 y 10 para {campo}.", "OK");
            valor = 0;
            return false;
        }
        return true;
    }
}