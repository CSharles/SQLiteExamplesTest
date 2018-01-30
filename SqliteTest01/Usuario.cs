using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTest01
{
    class Usuario
    {
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string nombreUsuario { get; set; }
        public string Conntra { get; set; }
        private DateTime? primerLog;

        public DateTime? PrimerLog
        {
            get { return primerLog; }
           private set {
                if (value == null)
                    primerLog = DateTime.Today;
                else
                    primerLog = value;
            }
        }

        public DateTime UltimoLog { get; set; }
        public Usuario(int id, DateTime? primerLog)
        {
            this.Id = id;
            this.PrimerLog = primerLog;
        }
        public Usuario()
        { }
    }

}
