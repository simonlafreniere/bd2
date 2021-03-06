CREATE OR REPLACE TRIGGER TR_IDLIT
BEFORE INSERT OR UPDATE 
OF IDLIT, PRIX, IDDORTOIR
on LIT
for each row

declare 
    NOMBRE integer := 1;
    CURSOR CR_ID IS SELECT * FROM LIT WHERE IDLIT=:NEW.IDLIT;
    ID_VAL LIT%ROWTYPE;
begin
    OPEN CR_ID;
    LOOP 
        FETCH CR_ID INTO ID_VAL;
        DBMS_OUTPUT.PUT_LINE('MA VALEUR EST : '||ID_VAL.IDLIT);
        
        IF(NOMBRE <= ID_VAL.IDLIT)THEN
        NOMBRE := ID_VAL.IDLIT + 1;
        END IF;
        EXIT WHEN CR_ID%NOTFOUND;
    END LOOP;
    CLOSE CR_ID;
    
    
    :NEW.IDLIT := NOMBRE;
END;

CREATE OR REPLACE TRIGGER AUTOINCREMENT
BEFORE INSERT OR UPDATE 
ON LIT
FOR EACH ROW
    BEGIN
        SELECT IDLIT.NEXTVAL
        INTO:NEW.IDLIT
        FROM DUAL;
    END;

CREATE SEQUENCE lit_seq START WITH 1;



CREATE OR REPLACE TRIGGER lit_autoinc 
BEFORE INSERT ON LIT
FOR EACH ROW

BEGIN
  SELECT lit_seq.NEXTVAL
  INTO   :new.IDLIT
  FROM   dual;
END;

insert into LIT (PRIX,IDDORTOIR) values(11.00,1);