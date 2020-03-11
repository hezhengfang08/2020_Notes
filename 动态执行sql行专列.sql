declare
  ----带参数
  var_date varchar2(2000);
  var_insql  varchar2(8000);
begin

    select listagg (to_char(PMDGUA001A, 'yyyy-mm-dd'), ''',''') WITHIN GROUP (ORDER BY SFBAUD005,SFBADOCNO) name into var_date from q501_tmp;
     var_date := ''''|| var_date || '''';
    dbms_output.put_line(var_date);
  var_insql := '  create table tt_test as select * from (select SFBAUD005,SFBADOCNO,to_char(PMDGUA001A, ''yyyy-mm-dd'') as tt from q501_tmp) 
pivot (max(tt) for tt in ('||var_date||' ))';
dbms_output.put_line(var_insql);
  execute immediate var_insql;
 commit;
end;

create table tt_test as select * from (select SFBAUD005,SFBADOCNO,PMDGUA001A from q501_tmp) 
pivot (max(PMDGUA001A) for PMDGUA001A in (01-10月-19,01-3月 -19,01-4月 -19,01-7月 -19 ))
