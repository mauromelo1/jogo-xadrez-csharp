
namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        } // fim Tabuleiro

        public Peca peca(int linha, int coluna) 
        {
            return pecas[linha, coluna];
        } // fim peca

        public Peca peca(Posicao pos) 
        {
            return pecas[pos.linha, pos.coluna];
        } // fim peca

        public bool existePeca(Posicao pos) 
        {
            validarPosicao(pos);
            return peca(pos) != null;
        } // fim existePeca

        public void colocarPeca(Peca p, Posicao pos) 
        {
            if (existePeca(pos)) 
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        } // fim colocarPeca

        public Peca retirarPeca(Posicao pos) 
        {
            if (peca(pos) == null) 
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        } // fim retirarPeca

        public bool posicaoValida(Posicao pos) 
        {
            if (pos.linha < 0 || pos.linha>= linhas || pos.coluna < 0 || pos.coluna >= colunas ) 
            {
                return false;             
            }
            return true;
        } // fim posicaoValida

        public void validarPosicao(Posicao pos) 
        {
            if (!posicaoValida(pos)) 
            {
                throw new TabuleiroException("Posição inválida! ");
            }        
        } // fim validarPosicao
    }
}
