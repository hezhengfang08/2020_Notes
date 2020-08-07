select DocumentNo,	Theme, AmountInvolved, BudgetSituation from 
(
select 	DocumentNo,	Theme, AmountInvolved, BudgetSituation from I_AQH_PriceParity a
join OT_InstanceContext b on  a.ObjectID = b.BizObjectId
where b.State = 4
union all
select DocumentNo,Theme, AmountInvolved, BudgetSituation from I_AQH_OpenTender a
join OT_InstanceContext b on  a.ObjectID = b.BizObjectId
where b.State = 4
union all
select DocumentNo,Theme, AmountInvolved, BudgetSituation from I_DirectCommittee a
join OT_InstanceContext b on  a.ObjectID = b.BizObjectId
where b.State = 4
) a


select * from I_AQH_OpenTender

select * from OT_InstanceContext where BizObjectId = '255783fb-a23a-4c6a-9753-a850ceae8838'