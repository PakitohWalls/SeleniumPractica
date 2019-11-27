using System;

namespace SeleniumPractica {

    public class Telefono
    {
        public String Modelo { get; set; }

        public String Precio { get; set; }

        public Telefono(String Modelo, String Precio)
        {
            this.Modelo = Modelo;
            this.Precio = Precio;
        }
    }

}
