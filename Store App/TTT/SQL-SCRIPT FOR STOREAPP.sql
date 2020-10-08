Go 
use master
 
DROP DATABASE IF EXISTS  VicheleStore
GO
CREATE DATABASE VicheleStore
GO
USE VicheleStore
GO
CREATE TABLE VehicleInfo
(VehicleID INT PRIMARY KEY,
VehicleName VARCHAR(80),
VehicleModel VARCHAR(80)
);
GO
INSERT INTO VehicleInfo(VehicleID,VehicleName,VehicleModel)
                  VALUES(100,'TOTOYA','X-998'),
				  (101,'TOTOYA','X-998'),
				    (102,'MARCHANDISE','Y-998'),
					  (103,'BUS','Z-998'),
					    (104,'TRAK','X-948'),
						  (105,'HARSE','H-998'),
						    (106,'NAHU-2','L-938');
GO

		SELECT * FROM VehicleInfo;