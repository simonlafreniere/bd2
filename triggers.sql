CREATE OR REPLACE TRIGGER dort_autoinc 
BEFORE INSERT ON DORTOIR
FOR EACH ROW

BEGIN
  SELECT dort_seq.NEXTVAL
  INTO   :new.IDDORTOIR
  FROM   dual;
END;

CREATE OR REPLACE TRIGGER chambre_autoinc 
BEFORE INSERT ON CHAMBRE
FOR EACH ROW

BEGIN
  SELECT chambre_seq.NEXTVAL
  INTO   :new.IDCHAMBRE
  FROM   dual;
END;

CREATE OR REPLACE TRIGGER client_autoinc 
BEFORE INSERT ON CLIENT
FOR EACH ROW

BEGIN
  SELECT client_seq.NEXTVAL
  INTO   :new.IDCLIENT
  FROM   dual;
END;

CREATE OR REPLACE TRIGGER res_autoinc 
BEFORE INSERT ON RESERVATION
FOR EACH ROW

BEGIN
  SELECT res_seq.NEXTVAL
  INTO   :new.IDRESERVATION
  FROM   dual;
END;