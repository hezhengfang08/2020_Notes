alter function GetStrFromXml
(
 @Instr xml,
 @Posb  varchar(10),
 @Pose  varchar(10)
)

--select dbo.GetStrFromXml('<123232><ererere><45454>','<','>')
returns varchar(2000)
as
begin 
   declare @Res  varchar(2000)
   declare @begin int
   declare @len int, @bLen int
   declare @end int, @rem int
   declare @temp varchar(max)
   set @temp = cast(@Instr as varchar(max))
   set @begin = charindex(@Posb, @temp)
   set @end = charindex(@Pose, @temp)
    set  @bLen = len(@Posb)
   set @len = @end -@begin-@bLen
   set @rem = len(@temp)-@end
  
  
   while (@begin >0)
   begin
      set @Res = isnull(@Res+',','')+'"'+ SUBSTRING(@temp,@begin+@bLen,@len)+'"'
	  
	  set @temp = SUBSTRING(@temp,@end+1, @rem)
	  set @begin = charindex(@Posb, @temp)
      set @end = charindex(@Pose, @temp)
	  set @len = @end -@begin-@bLen
      set @rem = len(@temp)-@end
   end

  return @Res
end 


