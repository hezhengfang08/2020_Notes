select distinct funcs, s.flowname, code, name, r.WorkflowName from I_UserWorkflowRelation s
join OT_OrgPost p on charindex(code, funcs)>0
join OT_WorkflowClause r on r.WorkflowCode = flowname


select * from OT_WorkflowClause

--1记录表
select funcs,charindex('"',funcs,0)as cnt1, charindex('"',funcs,charindex('"',funcs,0)+1) cnt2, flowname, remarks 
, SUBSTRING(funcs, charindex('"',funcs,0)+1, charindex('"',funcs,charindex('"',funcs,0)+1))

from I_UserWorkflowRelation
--2 角色表
select * from OT_OrgPost


select count(*) from I_UserWorkflowRelation


select * from OT_EnumerableMetadata where Category like '%业务内容%'