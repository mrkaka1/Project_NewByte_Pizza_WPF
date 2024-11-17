create database newbite;
use newbite;

# ====== Tabelas Livres ======
create table Endereco(
	id_end int primary key not null,
    cep_end varchar(8),
    rua_end varchar(200),
    numero_end int,
    bairro_end varchar(200),
    cidade_end varchar(200),
    estado_fend varchar(200)
);

create table Entrega (
	id_ent int primary key not null,
    tempo_estimado_ent time
);

create table Observacao(
	id_obs int primary key not null,
    descricao_obs varchar(500)
);

create table Alimento(
	id_ali int primary key not null,
    nome_ali varchar(300),
    valor_ali float,
    foto_ali blob
);

create table Estoque(
	id_est int primary key not null,
    tipo_medida_est varchar(20),
    quantidade_est int
);

create table Pagamento(
	id_pag int primary key not null,
    forma_pag varchar(300),
    valor_pag float,
    data_pag date,
    hora_pag time
);

# ====== Tabelas Semi-Livres ======
create table Credencial(
	id_cre int primary key not null,
    cpf_cre varchar(11),
    cnpj_cre varchar(14),
    insc_estadual_cre varchar(14),
    complemento_cre varchar(500),
    rg_cre varchar(6),
    telefone_cre varchar(11),
    email_cre varchar(200),
    senha_cre varchar(200),
    
    id_end_fk int,
    foreign key (id_end_fk) references Endereco(id_end)
);

create table Cliente(
	id_cli int primary key not null,
    nome_cli varchar(200),
    
    id_cre_fk int,
    foreign key (id_cre_fk) references Credencial(id_cre)
);

create table Funcionario(
    id_fun int primary key not null auto_increment,
    nome_fun varchar(200),
    email_fun varchar(200),
    senha_fun varchar(200),
    repetir_senha_fun varchar(200),
);

create table Produto(
	id_pro int primary key not null,
    nome_pro varchar(300),
    foto_pro blob,
    valor_pro float,

	id_est_fk int,
    foreign key (id_est_fk) references Estoque(id_est)
);

create table QuantidadePedido(
	id_qped int primary key not null,
    quantidade_qped int,
    
    id_ali_fk int,
    id_pro_fk int,
    foreign key (id_ali_fk) references Alimento(id_ali),
    foreign key (id_pro_fk) references Produto(id_pro)
);

create table Pedido(
	id_ped int primary key not null,
    status_ped boolean,
    
    id_ent_fk int,
    id_obs_fk int,
    id_qped_fk int,
    foreign key (id_ent_fk) references Entrega(id_ent),
    foreign key (id_obs_fk) references Observacao(id_obs),
    foreign key (id_qped_fk) references QuantidadePedido(id_qped)
);

create table Mesa(
	id_mes int primary key not null,

	id_ped_fk int,
    foreign key(id_ped_fk) references Pedido(id_ped)
);

create table Venda(
	id_ven int primary key not null,
    valor_total_ven float,
    desconto_ven int,
    data_abertura_ven date,
    data_fechamento_ven date,
    hora_abertura_ven date,
    hora_fechamento_ven date,
    status_ven boolean,
    
    id_pag_fk int,
    id_ped_fk int,
    foreign key(id_pag_fk) references Pagamento(id_pag),
    foreign key(id_ped_fk) references Pedido(id_ped)
);

create table Balcao(
	id_bal int primary key not null,
    numero_bal int,
    status_bal boolean,
    
    id_ven_fk int,
    foreign key(id_ven_fk) references Venda(id_ven)
);

create table Fornecedor(
	id_for int primary key not null,
    nome_for varchar(300),
    
    id_cre_fk int,
    id_pro_fk int,
    foreign key(id_pro_fk) references Produto(id_pro),
    foreign key(id_cre_fk) references Credencial(id_cre)
);

create table Cofre(
	id_cof int primary key not null,
    total_cof float,
    
	id_pag_fk int,
    foreign key(id_pag_fk) references Pagamento(id_pag)
);

# ====== Tabelas Presas ======
create table Acesso (
	id_ace int primary key not null,
    tipo_ace varchar(200),
    
    id_fun_fk int,
    foreign key (id_fun_fk) references Funcionario(id_fun)
);

create table Cargo (
	id_car int primary key not null,
    tipo_car varchar(200),
    
    id_fun_fk int,
    foreign key (id_fun_fk) references Funcionario(id_fun)
);

create table AlimenProd(
	id_aprod int primary key not null,
    
    id_ali_fk int,
    id_pro_fk int,
    foreign key(id_ali_fk) references Alimento(id_ali),
    foreign key(id_pro_fk) references Produto(id_pro)
);

create table CliMes(
	id_climes int primary key not null,
    
    id_cli_fk int,
    id_mes_fk int,
    foreign key(id_cli_fk) references Cliente(id_cli),
    foreign key(id_mes_fk) references Mesa(id_mes)
);

create table CliVen(
	id_cliven int primary key not null,
    
    id_cli_fk int,
    id_ven_fk int,
    foreign key(id_cli_fk) references Cliente(id_cli),
    foreign key(id_ven_fk) references Venda(id_ven)
);

create table BalFun(
	id_balfun int primary key not null,
    
    id_bal_fk int,
    id_fun_fk int,
    foreign key(id_bal_fk) references Balcao(id_bal),
    foreign key(id_fun_fk) references Funcionario(id_fun)
);
