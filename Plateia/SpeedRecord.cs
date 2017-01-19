using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateia
{
    class SpeedRecord
    {
        private int idatleta;
        private int iddupla;
        private int idevento;
        private int idduplasevento;
        private int velocidade;
        private int direcao;
        private long ticks;

        public int IdAtleta
        {
            get
            {
                return idatleta;
            }
        }

        public int IdDupla
        {
            get
            {
                return iddupla;
            }
        }

        public int IdDuplasEvento
        {
            get
            {
                return idduplasevento;
            }
        }

        public int IdEvento
        {
            get
            {
                return idevento;
            }
        }

        public int Velocidade
        {
            get
            {
                return velocidade;
            }
        }

        public int Direcao
        {
            get
            {
                return direcao;
            }
        }

        public long Ticks
        {
            get
            {
                return ticks;
            }
        }

        public SpeedRecord(int idatleta, int iddupla, int idevento, int idduplasevento, int velocidade, int direcao, long ticks)
        {
            this.idatleta = idatleta;
            this.iddupla = iddupla;
            this.idevento = idevento;
            this.idduplasevento = idduplasevento;
            this.velocidade = velocidade;
            this.direcao = direcao;
            this.ticks = ticks;
        }
    }
}
