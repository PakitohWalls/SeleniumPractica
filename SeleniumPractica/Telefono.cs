using System;

namespace SeleniumPractica {

    public class Telefono
    {
        public String Modelo { get; set; }

        public String Precio { get; set; }

        public String PrecioAnterior { get; set; }
        public Telefono(String Modelo, String Precio, String PrecioAnterior = "")
        {
            this.Modelo = Modelo;
            this.Precio = Precio;
            this.PrecioAnterior = PrecioAnterior;
        }

        public string ToString()
        {
            return this.Modelo + " / Precio: " + this.Precio + " / " + this.PrecioAnterior;
        }
    }

}
