using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest
{
    public partial class Cliente
    {
        public override string ToString()
        {
            return string.Format("{0:000}\t{1,-10}\t{2,-10}\t{3,3}", this.ClienteID, this.Nombre, this.Apellido, this.Edad);
        }
    }
}
