drop database if exists minuteWeather;

create database minuteWeather;
use minuteWeather;

drop table if exists users;
create table users (
	user_id int NOT NULL AUTO_INCREMENT, 
	first_name varchar(20), 
	last_name varchar(20), 
	phone VARCHAR(10), 
	city_name varchar(20), 
	state_code varchar(5),
	country_code varchar(10),
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
	user_id int NOT NULL AUTO_INCREMENT,
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
	user_id int NOT NULL AUTO_INCREMENT,
	alert_time time, 
	temp tinyint(1), 
	humidity tinyint(1), 
	precipitation tinyint(1), 
	wind tinyint(1), 
	uv tinyint(1), 
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);




insert into users(first_name, last_name, phone, city_name, state_code, country_code) 
	values('John', 'Jame', '1234678823', 'Brunswick', 'US-ME', '3166-2:US'), ('Kevin', 'Thomas', '8490879654', 'Portland', 'US-ME', '3166-2:US'), ('Carla', 'Williams', '9730198471', 'Augusta', 'US-ME', '3166-2:US');

    
insert into login(username, password) 
	values('LobstserFan01', 'BigClaw'), ('PortandSeaDogs', 'Homerun'), ('TractorSupply', 'CowFeed60');
    
insert into daily_alert(alert_time, temp, humidity, precipitation, wind, uv) 
	values ('13:30:00', 1, 0, 1, 0, 1), ('05:0:00', 1, 1, 1, 1, 0), ('16:45:00', 1, 1, 0, 0, 1);
    
insert into weekly_alert(alert_time, temp, humidity, precipitation, wind, uv) 

values ('12:30:00', 1, 0, 1, 1, 1), ('04:0:00', 1, 1, 0, 1, 0), ('14:45:00', 0, 1, 0, 0, 1);

