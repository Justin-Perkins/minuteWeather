drop database if exists weather_app;

create database weather_app;
use weather_app;

create table login (
	user_id int NOT NULL AUTO_INCREMENT,
    username varchar(20),
    password varchar(20),
    primary key(user_id));

create table users (
	user_id int NOT NULL AUTO_INCREMENT, 
	first_name varchar(20), 
	last_name varchar(20), 
	phone bigint, 
	city_name varchar(20), 
	state_code varchar(2),
	country_code varchar(2),
	alert_time time, 
	temp tinyint(1), 
	humidity tinyint(1), 
	precipitation tinyint(1), 
	wind tinyint(1), 
	uv tinyint(1), 
	PRIMARY KEY (user_id));

insert into users (first_name, last_name, phone, city_name, state_code, country_code, alert_time, temp, humidity, precipitation, wind, uv) values
	('John', 'Doe', 6031233456, 'Concord', 'NH', 'US', '12:30:00', 1, 0, 1, 1, 0);
