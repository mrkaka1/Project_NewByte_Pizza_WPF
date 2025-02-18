create database newbite;
use newbite;

# ====== Tabelas Livres ======
create table Endereco(
	id_end int primary key not null  auto_increment,
    cep_end varchar(8),
    rua_end varchar(200),
    numero_end int,
    bairro_end varchar(200),
    cidade_end varchar(200),
    estado_fend varchar(200)
);

create table Entrega (
	id_ent int primary key not null  auto_increment  auto_increment,
    tempo_estimado_ent time
);

create table Alimento(
	id_ali int primary key not null  auto_increment,
    nome_ali varchar(300),
    valor_ali float,
    foto_ali blob
);

create table Pagamento(
	id_pag int primary key not null  auto_increment,
    forma_pag varchar(300),
    valor_pag float,
    data_pag date,
    hora_pag time
);

create table Cliente(
	id_cli int primary key not null  auto_increment auto_increment,
    nome_cli varchar(200),
    email_cli varchar(200),
    telefone_cli varchar(11),
    cpf_cli varchar(200),
    senha_cli varchar(200)
);

insert into cliente values (null, "Admin", "admin@new.bite", "00000000000", "000.000.000-00", "a");

create table Funcionario(
    id_fun int primary key not null  auto_increment auto_increment,
    nome_fun varchar(200),
    email_fun varchar(200),
	telefone_fun varchar(11),
    cpf_fun varchar(200),
    acesso_fun varchar(200),
    cargo_fun varchar(100),
    senha_fun varchar(200)
);

create table Fornecedor(
	id_for int primary key not null  auto_increment,
    nome_for varchar(300),
    endereco_for varchar(300),
    cnpj_for varchar(18),
    cep_for varchar(9)    
);

create table Produto(
	id_pro int primary key not null  auto_increment,
    nome_pro varchar(300),
    valor_pro double,
    tipo_medida_pro varchar(20),
    quantidade_pro double
);

# ====== Tabelas Semi-Livres ======
create table QuantidadePedido(
	id_qped int primary key not null  auto_increment,
    quantidade_qped int,
    
    id_ali_fk int,
    id_pro_fk int,
    foreign key (id_ali_fk) references Alimento(id_ali),
    foreign key (id_pro_fk) references Produto(id_pro)
);

create table Pedido(
	id_ped int primary key not null  auto_increment,
    status_ped boolean,
    descricao_obs varchar(500),
    
    id_ent_fk int,
    id_qped_fk int,
    foreign key (id_ent_fk) references Entrega(id_ent),
    foreign key (id_qped_fk) references QuantidadePedido(id_qped)
);

create table Mesa(
	id_mes int primary key not null  auto_increment,

	id_ped_fk int,
    foreign key(id_ped_fk) references Pedido(id_ped)
);

create table Venda(
	id_ven int primary key not null  auto_increment,
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
	id_bal int primary key not null  auto_increment,
    numero_bal int,
    status_bal boolean,
    
    id_ven_fk int,
    foreign key(id_ven_fk) references Venda(id_ven)
);

create table Cofre(
	id_cof int primary key not null  auto_increment,
    total_cof float,
    
	id_pag_fk int,
    foreign key(id_pag_fk) references Pagamento(id_pag)
);

# ====== Tabelas Presas ======

create table AlimenProd(
	id_aprod int primary key not null  auto_increment,
    
    id_ali_fk int,
    id_pro_fk int,
    foreign key(id_ali_fk) references Alimento(id_ali),
    foreign key(id_pro_fk) references Produto(id_pro)
);

create table CliMes(
	id_climes int primary key not null  auto_increment,
    
    id_cli_fk int,
    id_mes_fk int,
    foreign key(id_cli_fk) references Cliente(id_cli),
    foreign key(id_mes_fk) references Mesa(id_mes)
);

create table CliVen(
	id_cliven int primary key not null  auto_increment,
    
    id_cli_fk int,
    id_ven_fk int,
    foreign key(id_cli_fk) references Cliente(id_cli),
    foreign key(id_ven_fk) references Venda(id_ven)
);

create table BalFun(
	id_balfun int primary key not null  auto_increment,
    
    id_bal_fk int,
    id_fun_fk int,
    foreign key(id_bal_fk) references Balcao(id_bal),
    foreign key(id_fun_fk) references Funcionario(id_fun)
);
