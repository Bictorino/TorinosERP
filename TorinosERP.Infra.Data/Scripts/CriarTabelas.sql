CREATE TABLE cliente (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    telefone VARCHAR(20)
);

CREATE TABLE produto (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    descricao TEXT,
    preco NUMERIC(10,2) NOT NULL CHECK (preco > 0),
    estoque INTEGER NOT NULL CHECK (estoque >= 0)
);

CREATE TABLE venda (
    id SERIAL PRIMARY KEY,
    cliente_id INTEGER NOT NULL REFERENCES cliente(id), 
    data_cadastro TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    data_venda TIMESTAMP,
    valor_total NUMERIC(10,2) NOT NULL DEFAULT 0,
    status INTEGER NOT NULL DEFAULT 0 
);


CREATE TABLE venda_item (
    id SERIAL PRIMARY KEY,
    venda_id INTEGER NOT NULL REFERENCES venda(id) ON DELETE CASCADE,
    produto_id INTEGER NOT NULL REFERENCES produto(id), 
    produto_nome VARCHAR(100) NOT NULL, 
    quantidade INTEGER NOT NULL CHECK (quantidade > 0),
    preco_unitario NUMERIC(10,2) NOT NULL CHECK (preco_unitario >= 0),
    subtotal NUMERIC(10,2) GENERATED ALWAYS AS (quantidade * preco_unitario) STORED
);

CREATE INDEX idx_venda_cliente ON venda(cliente_id);
CREATE INDEX idx_venda_item_venda ON venda_item(venda_id);
CREATE INDEX idx_venda_item_produto ON venda_item(produto_id);