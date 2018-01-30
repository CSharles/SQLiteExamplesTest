using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTest01
{
    class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public override string ToString()
        {
            return string.Format("{0:000}\t{1,-10}\t{2,-10}\t{3,3}",this.Id,this.Nombre,this.Apellido,this.Edad);
        }
    }
}
