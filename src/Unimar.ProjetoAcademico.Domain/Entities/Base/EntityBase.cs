using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Unimar.ProjetoAcademico.Domain.Entities.Base
{
    public abstract class EntityBase<TId>
    {
        public TId Id { get; set; }
        public DateTime? DataCadastro { get; set; }
    }



    //Guid -> e4d2d93f-5471-4fb3-b6dd-5a2edd157e19
    //int -> 1
    //string -> "edu"

}
