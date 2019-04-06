using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ListasDePixels
{
    class Comentarios
    {
        // Mão na Massa: Listas de Pixels e Outras Loucuras com Listas

        /*
         Neste Mão na Massa, e vamos mostrar como usar e abusar de listas para manipular uma imagem.

Localizando o projeto na pasta
Na pasta Aula6 da solução, temos um projeto chamado A2ListasDePixels.csproj, que também é do tipo Windows Forms.

Mais uma vez, não vamos entrar em detalhes aqui sobre Windows Forms, nem vamos explicar como funcionam os controles, painéis, etc. de Windows Forms. Em vez disso, abra o projeto que pedimos para baixar, e acompanhe como o código foi implementado.

O Código
Baseado no projeto do "Mão na Massa" anterior, desenvolvemos algumas funções para ler o conteúdo do Bitmap do ícone e exibi-lo ampliado na tela.

Vamos explicar alguns dos métodos utilizados:

Bitmap GetIconBitmap(): método que encapsula o código para obter o Bitmap a partir do arquivo do ícone (favicon.ico)
ReadOnlyCollection<Color> ObterCores(Bitmap bm): Método que recebe um Bitmap e obtém uma lista somente-leitura de cores (classe Color)
Color: um struct do sistema (namespace System.Drawing) que representa uma cor. Cada Color possui 4 propriedades: A, R, G, B, respectivamente: Alfa, Vermelho, Verde, Azul
void VisualizarIcone(List<Color> cores): Método que recebe uma lista de cores e exibe na tela os pixels do ícone. Cada pixel é representado por um controle Label do Windows Forms.
Opções do Menu
O formulário da aplicação tem um menu que contém várias opções para manipulação da imagem:



Para simplificar a explicação, vamos tratar somente de lista de cores (List<Color>), porém sem mostrar implementação específica do Windows Forms.

Obtendo a Imagem Normal
Essa é a opção mais simples do menu: apenas obtemos uma cópia das cores e em seguida enviamos essas cores para o método exibir uma imagem na janela:

private void UpdateImageNormal()
{
    List<Color> copiaCores = new List<Color>(cores);
    VisualizarIcone(copiaCores);
}
Note que estamos fazendo uma cópia da coleção cores, que é uma coleção somente-leitura (ReadOnlyCollection). Isso é bom para mantermos a coleção original cores sempre inalterada, garantindo que qualquer mudança seja feita sobre uma cópia.



A imagem acima é uma representação do mapa de pixels que está armazenado na nossa lista de cores (List<Color>).

Mas se nossa lista List<Color> só possui uma dimensão, como ela é mapeada para uma imagem bidimensional??

Simples:

a primeira linha contém os elementos de índice de 0 a 15
a segunda linha contém os elementos de índice de 16 a 31
etc.
Mas uma imagem vale mais que mil palavras! Vamos dar uma olhada mais de perto nesses pixels:



Girando a Imagem 180 Graus
Agora queremos pegar a imagem e girá-la em 180 graus. O canto superior esquerdo vira canto inferior direito. O canto superior direito vira canto infeior esquerdo, e assim por diante. Podemos simplesmente dizer que:

O primeiro pixel troca de lugar com o último
O segundo pixel troca de lugar com o penúltimo
O terceiro pixel troca de lugar com o antepenúltimo
etc.
Opa! Já vimos esse tipo de operação: podemos utilizar Reverse() para inverter a ordem dos pixels:

private void UpdateImageInvertida()
{
    List<Color> copiaCores = new List<Color>(cores);
    copiaCores.Reverse(); // inverter a imagem
    VisualizarIcone(copiaCores);
}
Agora sim, temos a imagem invertida:



PARA SABER MAIS:

O método Reverse() (MSDN)

Ordenando do Claro para o Escuro
Nesse comando precisamos exibir a imagem em ordem de claridade. Mas o que é "claridade"?

Lembra que uma cor tem 3 propriedades, R, G e B (Vermelho, Verde, Azul)? Imagine que essas 3 cores sejam lâmpadas coloridas. Quanto o maior o valor de R, G e B, mais claro é o pixel. Quanto menor o valor deles, mais escuro o pixel.

Então podemos ordenar esses pixels, traduzindo essa regra para uma expressão: color.A + color.R + color.G + color.B:

private void UpdateImageOrdenarClaroEscuro()
{
    List<Color> copiaCores = new List<Color>(cores);
    var ordenado = copiaCores
        .OrderByDescending(c => c.A + c.R + c.G + c.B)
        .ToList(); //do mais claro para o mais escuro

    VisualizarIcone(ordenado);
}
Mas note que usamos OrderByDescending e não OrderBy! Por quê?

Como queremos mostrar os mais claros primeiro, então temos que usar uma ordenação descrescente, onde o primeiro pixel tem o maior valor para c.A + c.R + c.G + c.B!



PARA SABER MAIS:

O método OrderByDescending (MSDN)

Ordenando do Escuro para o Claro


De forma inversa, agora podemos facilmente ordenar do mais escuro para o mais claro, porém desta vez vamos usar OrderBy em vez de OrderByDescending:

private void UpdateImageOrdenarEscuroClaro()
{
    List<Color> copiaCores = new List<Color>(cores);
    var ordenado = copiaCores
        .OrderBy(c => c.A + c.R + c.G + c.B)
        .ToList(); //do mais escuro para o mais claro
    VisualizarIcone(ordenado);
}
Note que, acima, você também poderia fazer um OrderByDescending() seguido de um Reverse()! Geralmente há mais de um caminho para a mesma solução!

PARA SABER MAIS:

O método OrderBy (MSDN)

Removendo a Metade Inferior
Se quisermos eliminar os pixels da parte de baixo da imagem, podemos removê-los com o método Remove. Mas são MUITOS pixels!

Em vez de sair criando um laço e removendo um por um, lembre-se de que vários métodos da classe List possuem uma opção para "trabalhar no atacado", isto é, para trabalhar com faixas de elementos. Vamos remover então uma faixa de elementos com RemoveRange:

private void UpdateImageRemoveMetadeInferior()
{
    List<Color> copiaCores = new List<Color>(cores);
    // remove a metade de baixo
    copiaCores.RemoveRange(bitmap.Width * (bitmap.Height / 2)
    , bitmap.Width * (bitmap.Height / 2));

    copiaCores.AddRange(Enumerable
        .Range(0, bitmap.Width * (bitmap.Height / 2))
        .Select(x => Color.White));
    VisualizarIcone(copiaCores);
}
Note que o número de pixels da imagem é dado pela fórmula largura X altura, ou : bitmap.Width * bitmap.Height. Mas como queremos remover somente metade dessa quantidade, usamos a expressão bitmap.Width * (bitmap.Height / 2).

Note também que no final do método usamos um AddRange() para preencher a cor branca o "buraco" causado pela remoção dos elementos. Esse preenchimento com AddRange() usa a expressão:

Enumerable
.Range(0, bitmap.Width * (bitmap.Height / 2))
.Select(x => Color.White)
Note que Enumerable.Range() é usado para gerar uma faixa de valores, que vai de 0 até metade da quantida de pixels.



PARA SABER MAIS:

O método AddRange() (MSDN)
O método RemoveRange() (MSDN)
O método Enumerable.Range() (MSDN)
Removendo a Metade Superior
Nessa caso não há muita coisa diferente com relação à função anterior, a não ser que estamos removendo (com RemoveRange) a partir do índice 0, isto é do início da lista, em vez de começar do meio da lista:

private void UpdateImageRemoveMetadeSuperior()
{
    List<Color> copiaCores = new List<Color>(cores);
    copiaCores.RemoveRange(0, bitmap.Width * (bitmap.Height / 2)); //remove a metade de cima
    copiaCores.InsertRange(0, Enumerable
        .Range(0, bitmap.Width * (bitmap.Height / 2))
        .Select(x => Color.White));
    VisualizarIcone(copiaCores);
}


PARA SABER MAIS:

O método InsertRange (MSDN)
Pintar a Metade Esquerda de Azul
Para definir os pixels da metade esquerda com a cor azul, podemos criar dois laços, um dentro do outro.

No laço exterior, vamos varrer as posições verticais (Y): for (int y = 0; y < bitmap.Height; y++)
No laço interior, vamos varrer as posições horizontais (X): for (int x = 0; x < bitmap.Width; x++)
Então calculamos o índice baseado nas coordenadas X e Y para definir a nova cor: azul escuro:

copiaCores[x + y * bitmap.Height] = Color.DarkBlue;
Porém, só queremos pintar a metade esquerda, lembra?

Então podemos limitar a varredura, até a metade da largura da imagem.

if (x < bitmap.Width / 2)
{
    copiaCores[x + y * bitmap.Height] = Color.DarkBlue;
}
Implementando o método, temos:

private void UpdateImagePintarEsquerdaAzul()
{
    List<Color> copiaCores = new List<Color>(cores);

    //PINTA A PARTE ESQUERDA DE AZUL
    for (int y = 0; y < bitmap.Height; y++)
    {
        for (int x = 0; x < bitmap.Width; x++)
        {
            if (x < bitmap.Width / 2)
            {
                copiaCores[x + y * bitmap.Height] = Color.DarkBlue;
            }
        }
    }
    VisualizarIcone(copiaCores);
}


Pintar a Metade Direita de Laranja
Esse método é bastante similar ao anterior. As únicas diferenças é que vamos começar a pintar a partir da metade horizontal: if (x >= bitmap.Width / 2) e a nova cor, laranja: Color.Orange.

private void UpdateImagePintarDireitaLaranja()
{
    List<Color> copiaCores = new List<Color>(cores);
    //PINTA A PARTE DIREITA DE LARANJA
    for (int y = 0; y < bitmap.Height; y++)
    {
        for (int x = 0; x < bitmap.Width; x++)
        {
            if (x >= bitmap.Width / 2)
            {
                copiaCores[x + y * bitmap.Height] = Color.Orange;
            }
        }
    }
    VisualizarIcone(copiaCores);
}


Duplicar a Metade de Baixo
Para realizar essa tarefa, bastam 2 passos:

Remover metade dos elementos (com RemoveRange()) , começando do primeiro até metade da lista. Com isso vão sobrar somente a última metade dos elementos
copiando os elementos da coleção nela mesma (com AddRange()). Assim a coleção terá 2 blocos idênticos.
private void UpdateImageDuplicarMetadeBaixo()
{
    List<Color> copiaCores = new List<Color>(cores);

    copiaCores.RemoveRange(0, bitmap.Width * (bitmap.Height / 2)); // remove a parte de cima
    copiaCores.AddRange(copiaCores); //duplica o bloco de elementos

    VisualizarIcone(copiaCores);
}


Duplicar a Metade de Cima
Essa é uma variação do problema anterior. Mas nesse caso, vamos remover os elementos da parte de baixo, com RemoveRange(), isto é, começando pela metade e indo até o final da lista.

private void UpdateImageDuplicarMetadeCima()
{
    List<Color> copiaCores = new List<Color>(cores);
    copiaCores.RemoveRange(bitmap.Width * (bitmap.Height / 2), bitmap.Width * (bitmap.Height / 2)); // remove a parte de baixo
    copiaCores.AddRange(copiaCores); //duplica o bloco de elementos
    VisualizarIcone(copiaCores);
}


Obtendo a Cor Média
Uma cor é formada por 4 componentes (A, R, G e B), portanto podemos obter a cor média gerando uma cor a partir das médias desses componentes A, R, G, e B.

"Média" em inglês é "Average", logo vamos usar o método Average(). Esse método pode receber uma expressão lambda que será a propriedade da cor para a qual queremos calcular a média aritmética:

private void UpdateImageCorMedia()
{
    List<Color> copiaCores = new List<Color>(cores);

    int corMediaA = (int)copiaCores.Average(c => c.A); 
    int corMediaR = (int)copiaCores.Average(c => c.R);
    int corMediaG = (int)copiaCores.Average(c => c.G);
    int corMediaB = (int)copiaCores.Average(c => c.B);
    Color corMedia = Color.FromArgb(corMediaA, corMediaR, corMediaG, corMediaB);

    for (int i = 0; i < copiaCores.Count; i++)
    {
        copiaCores[i] = corMedia;
    }

    VisualizarIcone(copiaCores);
}


PARA SABER MAIS:

O método Average (MSDN)
Obtendo a Cor Mais Clara
Como vimos anteriormente, a cor mais clara pode ser obtida calculando sua claridade:

claridade = `color.A + color.R + color.G + color.B`
E se calcularmos as claridades de cada pixel, poderemos ordenar a lista, do mais claro para o mais escuro, e em seguida pegar o primeiro valor (mais claro) com o método First():

private void UpdateImageCorMaisClara()
{
    List<Color> copiaCores = new List<Color>(cores);

    Color corMaisClara = copiaCores.OrderBy(c => c.A + c.R + c.G + c.B).First();

    for (int i = 0; i < copiaCores.Count; i++)
    {
        copiaCores[i] = corMaisClara;
    }

    VisualizarIcone(copiaCores);
}


PARA SABER MAIS:

O método First (MSDN)
Obtendo a Cor Mais Escura
Para pegarmos a cor mais escura, basta realizarmos o mesmo procedimento do método anterior, porém desta vez vamos pegar o último elemento (mais escuro) com o método Last():

private void UpdateImageCorMaisEscura()
{
    List<Color> copiaCores = new List<Color>(cores);

    Color corMaisEscura = copiaCores.OrderBy(c => c.A + c.R + c.G + c.B).Last();

    for (int i = 0; i < copiaCores.Count; i++)
    {
        copiaCores[i] = corMaisEscura;
    }

    VisualizarIcone(copiaCores);
}


PARA SABER MAIS:

O método Last (MSDN)
Virando a Imagem Horizontalmente
Para terminar, vamos girar a imagem horizontalmente e para isso vamos usar e abusar do LINQ (Language Integrated Queries, ou Consultas Integradas à Linguagem).

Pra isso, podemos realizar os seguintes passos:

1- quebrar a lista em grupos de N pixels, cada grupo representando uma linha diferente 2- inverter a ordem dos elementos de cada um desses grupos 3- juntar esses grupos em uma lista de listas 4- "achatar" essa lista de listas numa lista única

Como fica a implementação?

private void UpdateVirarHorizontal()
{
    List<Color> copiaCores = new List<Color>(cores);

    //a implementação vai aqui...

    VisualizarIcone(copiaCores);
}
1- quebrar a lista em grupos de N pixels, cada grupo representando uma linha diferente

Uma "quebra em grupos" é representada em LINQ com o método GroupBy():

copiaCores.GroupBy(...)
Mas para agruparmos, precisamos do número da linha, que não temos. Para trabalharmos com o número da linha, primeiro precisamos conhecer o índice de cada elemento da lista, para só então calcularmos o número da linha.

Como o objeto Color não possui a informação do índice do elemento, vamos usar o método Select(), que pode fornecer a informação do índice do elemento. Assim, vamos transformar nossa lista de cores numa lista de objetos anônimos, contendo a cor e também o índice:

copiaCores
    .Select((c, i) => new { Cor = c, Index = i })
Agora sim, vamos voltar ao método GroupBy(). E como temos que agrupar por número de linha, podemos calcular esse número dividindo o índice pela largura do bitmap:

.GroupBy(x => x.Index / bitmap.Width)
2- inverter a ordem dos elementos de cada um desses grupos

Temos que reverter os elementos de cada grupo. Mas primeiro vamos descartar o índice, fazendo um Select para obter somente a cor do elemento:

.Select(x => x.Select(v => v.Cor))
Agora sim, vamos inverter a ordem da linha com o método Reverse():

.Select(x => x.Select(v => v.Cor).Reverse().ToList())
3- juntar esses grupos em uma lista de listas

Agora sim, vamos juntar todos os grupos numa lista de listas:

var query
    = copiaCores
        .Select((c, i) => new { Cor = c, Index = i })
        .GroupBy(x => x.Index / bitmap.Width)
        .Select(x => x.Select(v => v.Cor).Reverse().ToList())
        .ToList();
4- "achatar" essa lista de listas numa lista única

Nosso método VisualizarIcone() trabalha com uma lista de cores, e não com uma lista de listas. Vamos "achatar" essa lista de listas, gerando uma lista única. Para "achatar" uma lista de listas, temos que usar o método SelectMany():

var juntarVariasListasNumaSo = query.SelectMany(x => x).ToList();

VisualizarIcone(juntarVariasListasNumaSo);
Agora sim, temos o método completo:

private void UpdateVirarHorizontal()
{
    List<Color> copiaCores = new List<Color>(cores);

    var query
        = copiaCores
            .Select((c, i) => new { Cor = c, Index = i })
            .GroupBy(x => x.Index / bitmap.Width)
            .Select(x => x.Select(v => v.Cor).Reverse().ToList())
            .ToList();

    var juntarVariasListasNumaSo = query.SelectMany(x => x).ToList();

    VisualizarIcone(juntarVariasListasNumaSo);
}


PARA SABER MAIS:

O método Select (MSDN)
O método GroupBy (MSDN)
O método SelectMany (MSDN)
CONHEÇA TAMBÉM NOSSOS CURSOS DE ENTITY LINQ!

Entity LinQ parte 1: Crie queries poderosas em C# (Alura)
Entity LinQ parte 2: Store Procedures e consultas com o LinQPad (Alura)
Ufa! E assim chegamos ao final de mais um Mão na Massa. Até à próxima!
         */
    }
}
