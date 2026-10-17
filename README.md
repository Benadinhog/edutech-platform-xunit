# EduTechPlatform

Plataforma acadêmica de exemplo desenvolvida em **.NET 10** para a lista de exercícios da disciplina **Garantia da Qualidade de Software / Gestão e Qualidade de Software**.

O projeto demonstra boas práticas de qualidade de software: regras de negócio isoladas em classes de serviço e cobertas por **testes unitários parametrizados com xUnit**.

---

## 📚 Visão geral

A aplicação simula rotinas de uma plataforma educacional em três domínios:

| Domínio | Responsabilidade |
|---|---|
| **Desempenho acadêmico** | Cálculo da média ponderada e definição da situação do aluno |
| **Frequência** | Cálculo do percentual de presença e aprovação por frequência |
| **Financeiro / Matrícula** | Cálculo da mensalidade e elegibilidade à rematrícula |

---

## 🗂️ Estrutura do repositório

```
edutech-platform-xunit/
├── EduTechPlatform.App/                     # Regras de negócio + console de demonstração
│   ├── NotaDesempenhoService.cs
│   ├── FrequenciaService.cs
│   ├── MatriculaFinanceiraService.cs
│   ├── Program.cs
│   └── EduTechPlatform.App.csproj
├── EduTechPlatform.Tests/                   # Testes unitários (xUnit)
│   ├── NotaDesempenhoServiceTests.cs
│   ├── FrequenciaServiceTests.cs
│   ├── MatriculaFinanceiraServiceTests.cs
│   └── EduTechPlatform.Tests.csproj
├── .gitignore
├── LICENSE
└── README.md
```

---

## ✅ Requisitos

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) ou superior.
- Verifique a instalação com:

```bash
dotnet --version
```

---

## ⚙️ Como executar

```bash
# 1. Clonar o repositório
git clone https://github.com/Benadinhog/edutech-platform-xunit.git
cd edutech-platform-xunit

# 2. Compilar a aplicação (as dependências são restauradas automaticamente)
dotnet build EduTechPlatform.App/EduTechPlatform.App.csproj

# 3. Executar o console de demonstração
dotnet run --project EduTechPlatform.App/EduTechPlatform.App.csproj

# 4. Executar os testes unitários
dotnet test EduTechPlatform.Tests/EduTechPlatform.Tests.csproj
```

---

## 🧩 Regras de negócio (classes de serviço)

### `NotaDesempenhoService`

| Método | Regra implementada |
|---|---|
| `CalcularMediaPonderada(decimal nota1, decimal nota2, decimal notaProjeto)` | Média ponderada com pesos 3, 3 e 4: `((nota1 * 3) + (nota2 * 3) + (notaProjeto * 4)) / 10` |
| `ObterSituacaoAcademica(decimal mediaFinal)` | `mediaFinal >= 7,0` → `"APROVADO"`; entre `5,0` e `6,99` → `"RECUPERACAO"`; `< 5,0` → `"REPROVADO"` |

### `FrequenciaService`

| Método | Regra implementada |
|---|---|
| `CalcularPorcentagemPresenca(int aulasTotais, int faltas)` | Percentual de presença: `((aulasTotais - faltas) / (double)aulasTotais) * 100` |
| `AprovadoPorFrequencia(int aulasTotais, int faltas)` | `true` quando a presença é **maior ou igual a 75%**; caso contrário, `false` |

### `MatriculaFinanceiraService`

| Método | Regra implementada |
|---|---|
| `CalcularValorMensalidade(decimal valorBase, int diaPagamento, bool eBolsista)` | Bolsista → 50% de desconto (`valorBase * 0.50m`); não bolsista pagando **até o dia 5** → 10% de desconto (`valorBase * 0.90m`); após o dia 5 → valor integral |
| `PodeRealizarRematricula(bool possuiPendenciaFinanceira, string situacaoAcademica)` | `true` apenas quando **não há pendência financeira** e a situação acadêmica **não é** `"REPROVADO"` |

---

## 🧪 Testes parametrizados (`[Theory]` / `[InlineData]`)

Os testes utilizam o atributo `[Theory]` combinado com `[InlineData]`, permitindo validar vários cenários em um único método de teste. Cada linha de `[InlineData]` representa um caso de entrada e o respectivo resultado esperado.

```csharp
[Theory]
[InlineData(7.0, 7.0, 7.0, 7.0)]
[InlineData(10.0, 10.0, 5.0, 8.0)]
public void CalcularMediaPonderada_DeveRetornarMediaEsperada(
    decimal nota1, decimal nota2, decimal notaProjeto, decimal mediaEsperada)
{
    var service = new NotaDesempenhoService();

    var media = service.CalcularMediaPonderada(nota1, nota2, notaProjeto);

    Assert.Equal(mediaEsperada, media);
}
```

Confira abaixo o que cada suíte cobre:

- **`NotaDesempenhoServiceTests`** — média ponderada e situação acadêmica.
- **`FrequenciaServiceTests`** — percentual de presença e aprovação por frequência.
- **`MatriculaFinanceiraServiceTests`** — valor da mensalidade e elegibilidade para rematrícula.

Para executar toda a suíte:

```bash
dotnet test EduTechPlatform.Tests/EduTechPlatform.Tests.csproj
```

---

## 📄 Licença

Distribuído sob a **Licença MIT**. Consulte o arquivo [LICENSE](LICENSE) para mais detalhes.
