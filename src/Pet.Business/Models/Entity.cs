using System;

namespace Pet.Business.Models
{
    public abstract class Entity //abstract - não poderá ser instanciada, tem que ser implementada, será herdada pelas demais
    {
        protected Entity() //como a classe só pode ser herdada, pode ser protected apenas as classes que herdarem terão acesso ao mesmo..
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
