drop database if exists weather_app;

create database weather_app;
use weather_app;

drop table if exists users;
create table users (
	user_id int NOT NULL AUTO_INCREMENT, 
	first_name varchar(20), 
	last_name varchar(20), 
	phone bigint, 
	city_name varchar(20), 
	state_code varchar(2),
	country_code varchar(2),
    PRIMARY KEY(user_id)
);

drop table if exists login;
create table login (
	user_id int NOT NULL AUTO_INCREMENT,
    username varchar(20),
    password varchar(20),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);
    
drop table if exists daily_alert;
create table daily_alert(
	user_id int,
	alert_time time, 
	temp tinyint(1), 
	humidity tinyint(1), 
	precipitation tinyint(1), 
	wind tinyint(1), 
	uv tinyint(1), 
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

drop table if exists weekly_alert;
create table weekly_alert(
	user_id int,
	alert_time time, 
	temp tinyint(1), 
	humidity tinyint(1), 
	precipitation tinyint(1), 
	wind tinyint(1), 
	uv tinyint(1), 
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

insert into users (first_name, last_name, phone, city_name, state_code, country_code) values
	('John', 'Doe', 6031233456, 'Concord', 'NH', 'US');

Select * from users;
