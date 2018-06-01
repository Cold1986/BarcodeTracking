--select DISTINCT(CDEFINE23) FROM dbo.KGM_HISTORYBODY   where cdefine25 ='911504482'

--UPDATE KGM_HISTORYBODY SET QTY=80 WHERE cdefine25 ='911503200' AND CDEFINE23='SO17026247'

--UPDATE KGM_HISTORYBODY SET QTY=64 WHERE cdefine25 ='911504482' AND CDEFINE23='SO17026247'


--select CDEFINE23 as '出货单/转仓单',CDEFINE25 as 'JDE料号',sum(QTY  )
--FROM dbo.KGM_HISTORYBODY   
--where datediff(dd,operdate,getdate())=0

--group by CDEFINE23,CDEFINE25
--order by CDEFINE23,CDEFINE25


--设置变量@now,程序会计算@now -1 天的8点 至 @now 的8天数量
--e.g @now=2017-12-18, 计算的量为 2017-12-17 08:00:000 至2017-12-18 08:00:000 数据

declare @now datetime
SET @now='2017-12-15'  
SET @now=dateadd(HH,8,@now)

select count(CDEFINE23)  FROM dbo.KGM_HISTORYBODY   
where operdate > @now and operdate< DATEADD(dd,1,@now)


select CDEFINE23 as '出货单/转仓单',sum(QTY  )
FROM dbo.KGM_HISTORYBODY   
where operdate > @now and operdate< DATEADD(dd,1,@now)

group by CDEFINE23
order by CDEFINE23


select sum(QTY) FROM dbo.KGM_HISTORYBODY  where  operdate > @now and operdate< DATEADD(dd,1,@now)