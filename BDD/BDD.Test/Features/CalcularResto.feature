#language: pt-br

Funcionalidade: CalcularResto


Cenário: Calcular resto entre dois numeros
	Dado que naveguei para pagina da calculadora de resto
	E que o valor inserindo no dividendo é 20
    E que o valor inserido no divisor é 10 
	Quando ao um clicar em calcular resto
	Entao o resultado do resto é 0 
	E o resultado da divisão é 2

Cenário: Calcular resto entre dois numeros com varios cenarios
	Dado que naveguei para pagina da calculadora de resto
	E que o valor inserindo no dividendo é <dividendo>
    E que o valor inserido no divisor é <divisor> 
	Quando ao um clicar em calcular resto
	Entao o resultado do resto é <resto>
	E o resultado da divisão é <resultado>

Exemplos: 
    | dividendo | divisor | resto | resultado        |
    | -10       | 2       | 0     |   -5             |
    | 45        | 4       | 1     |  11.25           |
    | 6         | -9      | 1     | -0,66666666666667|