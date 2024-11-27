USE companhia_aerea;

-- Insert into cliente
INSERT INTO cliente (nome, endereco, telefone, email, num_voos) VALUES
('Marcos', 'Rua Dois, 3', '3271687312', 'marcos@gmail.com', 6),
('Dani', 'Rua Jon De Duque, 922', '2342123412', 'dani@gmail.com', 12),
('Silas', 'Rua Anjos, 3', '122231', 'silas@gmail.com', 123);

-- Insert into aeronave
INSERT INTO aeronave (tipo, poltronas, modelo) VALUES
('Porte grande', 233, 'Boeing'),
('Porte pequeno', 70, 'Skycatcher'),
('Porte médio', 156, 'Dreamline'),
('Porte médio', 150, 'Skyliner');

-- Insert into aeroporto
INSERT INTO aeroporto (nome, rua, numero, bairro, cidade, estado, pais) VALUES
('Aeroporto Frota', 'Cerejas', '312', 'Itaquera', 'Tubarão', 'Santa Catarina', 'Brasil'),
('Skiller', 'Wrusiaw', '786', 'Wisden', 'Berna', 'Berna', 'Suíça'),
('Aeroporto de Dubai (DXB)', 'Al Garhoud', '10', 'Al Garhoud', 'Dubai', 'Dubai', 'Emirados Árabes');

-- Insert into voo
INSERT INTO voo (id_aeronave, id_aeroporto_origem, id_aeroporto_destino, saida, previsao_chegada) VALUES
(2, 1, 2, '2024-06-10 08:30:00', '2024-06-10 09:30:00'),
(2, 2, 3, '2024-06-11 09:15:00', '2024-06-11 15:15:00'),
(1, 3, 1, '2024-09-23 08:50:00', '2024-09-23 17:50:00'),
(2, 1, 2, '2024-12-03 19:50:00', '2024-12-03 22:50:00'),
(1, 1, 3, '2024-08-06 22:50:00', '2024-08-07 03:50:00'),
(3, 2, 3, '2024-07-12 02:50:00', '2024-07-12 05:50:00');

-- Insert into poltrona
INSERT INTO poltrona (id_aeronave, disponivel, localizacao) VALUES
(2, 0, 'K4'),
(1, 1, 'C3'),
(2, 1, 'R5'),
(3, 1, 'D6'),
(1, 0, 'T7'),
(1, 1, 'I9'),
(3, 0, 'K4'),
(2, 0, 'K9'),
(2, 1, 'A16'),
(3, 0, 'B17'),
(1, 1, 'C18'),
(2, 0, 'D19'),
(3, 1, 'E20'),
(1, 0, 'F21'),
(2, 1, 'G22'),
(3, 1, 'H23'),
(1, 0, 'I24'),
(3, 1, 'J25');

-- Insert into passageiro
INSERT INTO passageiro (id_cliente, id_voo, passagem, id_poltrona) VALUES
(2, 2, 4312, 5),
(1, 3, 23343, 7),
(3, 1, 43257, 1);

-- Insert into horario
INSERT INTO horario (id_voo, data, inicio_horario, final_horario) VALUES
(1, '2023-01-10', '07:00:00', '08:00:00'),
(3, '2022-03-11', '08:00:00', '09:00:00'),
(2, '2021-08-12', '06:00:00', '07:00:00');

-- Insert into escala
INSERT INTO escala (id_voo, id_aeroporto, saida) VALUES
(1, 3, '2024-06-12 06:50:00'),
(2, 1, '2024-07-11 08:50:00'),
(3, 2, '2024-11-22 08:10:00'),
(4, 3, '2024-07-12 04:23:00'),
(5, 2, '2024-07-16 08:20:00'),
(6, 1, '2024-10-23 08:32:00');
