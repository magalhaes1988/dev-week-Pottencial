using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev_week_Pottencial.src.Models
{
    public class Contracts
    {

        public Contracts()
        {

        }

        public Contracts(string tokenId, double valor, int idPessoa, bool pago = false)
        {
            this.DataCriacao = DateTime.Now;
            this.Valor = valor;
            this.TokenId = tokenId;
            this.Pago = pago;
            this.IdPessoa = idPessoa;
        }
        private int _id;

        private DateTime _datacriacao;
        private string _tokenId;
        private double _valor;

        private bool _pago;

        private int _idPessoa;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string TokenId
        {
            get { return _tokenId; }
            set { _tokenId = value; }
        }
        public double Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        public bool Pago
        {
            get { return _pago; }
            set { _pago = value; }
        }

        public DateTime DataCriacao
        {
            get { return _datacriacao; }
            set { _datacriacao = value; }
        }
        public int IdPessoa
        {
            get { return _idPessoa; }
            set { _idPessoa = value; }

        }
    }
}