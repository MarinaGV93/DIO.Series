using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

//Fazer um "meio de campo" entre o programa e o "BD", que é a Lista


namespace DIO.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie> //Passa a classe
    {
        private List<Serie> listaSerie = new List<Serie>();
        
        public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id] = entidade; //Recebe a entidade e vai colocar na posição do vetor listaSerie
        }

        public void Exclui(int id)
        {
            // listaSerie.RemoveAt(id);//Quando remover um, vai modificar os ID dos outros. Se usa com BD
            listaSerie[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}