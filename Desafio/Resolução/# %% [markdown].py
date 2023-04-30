# %% [markdown]
# ### Importações
#

# %%
import pandas as pd

# %% [markdown]
# #### Criando um DataFrame

# %%
df = pd.DataFrame(
    {
        "Produto": [16320, 23400, 26440, 28790, 36540],
        "QtCO": [344, 1435, 2899, 310, 431],
        "QtMin": [200, 500, 800, 150, 100],
        "QtVendas": [128, 937, 239, 245, 617],
    }
)

# %% [markdown]
# #### Adicionando a Coluna Estq. após vendas
#

# %%
df["Estq. após vendas"] = df["QtCO"] - df["QtVendas"]

# %% [markdown]
# #### Adicionando a Coluna Necess.


# %%
def completa_quantidade(row):
    if row["Estq. após vendas"] < row["QtMin"]:
        return row["QtMin"] - row["Estq. após vendas"]
    else:
        return 0


df["Necess."] = df.apply(lambda row: completa_quantidade(row), axis=1)

# %% [markdown]
# #### Adicionando a Coluna Transf. de Arm p/ CO


# %%
def transfere(row):
    if row["Necess."] > 1 and row["Necess."] < 10:
        return 10 or row["Necess."]
    else:
        return row["Necess."]


df["Transf. de Arm p/ CO"] = df.apply(lambda row: transfere(row), axis=1)

# %% [markdown]
# ### Setando a coluna Produto retirando o index

# %%
df.set_index("Produto")

# %% [markdown]
# #### Adicionando o Título a Tabela

# %%
df.style.set_caption("Necessidade de Transferência Armazém para CO")
