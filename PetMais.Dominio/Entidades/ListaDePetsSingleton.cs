using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Dominio.Entidades
{
    public sealed class ListaDePets
    {
        private static List<Pet> _pets;

        private ListaDePets() { }

        public static List<Pet> GetInstancia()
        {
            {
                if (_pets == null)
                {
                    _pets = new List<Pet>();
                }

                return _pets;
            }
        }

        public static int AutoIncrementoDeId()
        {
            const int incremento = 1;

            if (_pets.Count > 0)
            {
                return _pets.Max(pet => pet.Id) + incremento;
            }
            else
            {
                return incremento;
            }
        }
    }
}
