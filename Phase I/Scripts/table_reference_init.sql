reference_init
select * from view_reference
use ks_hty;

truncate table reference

insert into reference(Project,Color,BoxType, Version,APN,Label,HotPermJDE,ColdPermJDE,OEM) values
('HTY1','A' ,'小款' ,'美国版(US)' ,'677-10307' ,'677-10307-A-R' ,'911503174' ,'911504604' ,'677-10307-RRD' ),
('HTY1' ,'A' ,'小款' ,'美国版(US)' ,'677-10307' ,'677-10307-A-R' ,'911505092' ,'911505113' ,'677-10307' ),

('HTY1' ,'A' ,'小款' ,'美国版ROW(US)' ,'677-10310' ,'677-10310-A-R' ,'911503177' ,'911504607' ,'677-103107-RRD' ),
('HTY1' ,'A' ,'小款' ,'美国版ROW(US)' ,'677-10310' ,'677-10310-A-R' ,'911505095' ,'911505116' ,'677-10310' ),

('HTY1' ,'A' ,'小款' ,'中国版(CH)' ,'677-10313' ,'677-10313-A-R' ,'911503180' ,'911504610' ,'677-103137-RRD' ),
('HTY1' ,'A' ,'小款' ,'中国版(CH)' ,'677-10313' ,'677-10313-A-R' ,'911505098' ,'911505119' ,'677-10313' ),

('HTY1' ,'A' ,'小款' ,'澳洲版(AUS)' ,'677-10319' ,'677-10319-A-R' ,'911503186' ,'911504616' ,'677-103197-RRD' ),
('HTY1' ,'A' ,'小款' ,'澳洲版(AUS)' ,'677-10319' ,'677-10319-A-R' ,'911505104' ,'911505125' ,'677-10319' ),

('HTY1' ,'A' ,'小款' ,'欧洲版(EU)' ,'677-10316' ,'677-10316-A-R' ,'911503183' ,'911504613' ,'677-103167-RRD' ),
('HTY1' ,'A' ,'小款' ,'欧洲版(EU)' ,'677-10316' ,'677-10316-A-R' ,'911505101' ,'911505122' ,'677-10316' ),

('HTY1' ,'A' ,'小款' ,'印度版(IND)' ,'677-10322' ,'677-10322-A-R' ,'911503189' ,'911504619' ,'677-103227-RRD' ),
('HTY1' ,'A' ,'小款' ,'印度版(IND)' ,'677-10322' ,'677-10322-A-R' ,'911505107' ,'911505128' ,'677-10322' ),

('HTY1' ,'A' ,'中款' ,'英国版(UK)' ,'677-10325' ,'677-10325-A-R' ,'911503192' ,'911504622' ,'677-103257-RRD' ),
('HTY1' ,'A' ,'中款' ,'英国版(UK)' ,'677-10325' ,'677-10325-A-R' ,'911505110' ,'911505131' ,'677-10325' ),

('HTY1' ,'B' ,'小款' ,'美国版(US)' ,'677-10308' ,'677-10308-A-R' ,'911503175' ,'911504605' ,'677-103087-RRD' ),
('HTY1' ,'B' ,'小款' ,'美国版(US)' ,'677-10308' ,'677-10308-A-R' ,'911505093' ,'911505114' ,'677-10308' ),

('HTY1' ,'B' ,'小款' ,'美国版ROW(US)' ,'677-10311' ,'677-10311-A-R' ,'911503178' ,'911504608' ,'677-103117-RRD' ),
('HTY1' ,'B' ,'小款' ,'美国版ROW(US)' ,'677-10311' ,'677-10311-A-R' ,'911505096' ,'911505117' ,'677-10311' ),

('HTY1' ,'B' ,'小款' ,'中国版(CH)' ,'677-10314' ,'677-10314-A-R' ,'911503181' ,'911504611' ,'677-103147-RRD' ),
('HTY1' ,'B' ,'小款' ,'中国版(CH)' ,'677-10314' ,'677-10314-A-R' ,'911505099' ,'911505120' ,'677-10314' ),

('HTY1' ,'B' ,'小款' ,'澳洲版(AUS)' ,'677-10320' ,'677-10320-A-R' ,'911503187' ,'911504617' ,'677-103207-RRD' ),
('HTY1' ,'B' ,'小款' ,'澳洲版(AUS)' ,'677-10320' ,'677-10320-A-R' ,'911505105' ,'911505126' ,'677-10320' ),

('HTY1' ,'B' ,'小款' ,'欧洲版(EU)' ,'677-10317' ,'677-10317-A-R' ,'911503184' ,'911504614' ,'677-103177-RRD' ),
('HTY1' ,'B' ,'小款' ,'欧洲版(EU)' ,'677-10317' ,'677-10317-A-R' ,'911505102' ,'911505123' ,'677-10317' ),

('HTY1' ,'B' ,'小款' ,'印度版(IND)' ,'677-10323' ,'677-10323-A-R' ,'911503190' ,'911504620' ,'677-103237-RRD' ),
('HTY1' ,'B' ,'小款' ,'印度版(IND)' ,'677-10323' ,'677-10323-A-R' ,'911505108' ,'911505129' ,'677-10323' ),

('HTY1' ,'B' ,'中款' ,'英国版(UK)' ,'677-10326' ,'677-10326-A-R' ,'911503193' ,'911504623' ,'677-103267-RRD' ),
('HTY1' ,'B' ,'中款' ,'英国版(UK)' ,'677-10326' ,'677-10326-A-R' ,'911505111' ,'911505132' ,'677-10326' ),

('HTY1' ,'D' ,'小款' ,'美国版(US)' ,'677-10309' ,'677-10309-A-R' ,'911503176' ,'911504606' ,'677-103097-RRD' ),
('HTY1' ,'D' ,'小款' ,'美国版(US)' ,'677-10309' ,'677-10309-A-R' ,'911505094' ,'911505115' ,'677-10309' ),

('HTY1' ,'D' ,'小款' ,'美国版ROW(US)' ,'677-10312' ,'677-10312-A-R' ,'911503179' ,'911504609' ,'677-103127-RRD' ),
('HTY1' ,'D' ,'小款' ,'美国版ROW(US)' ,'677-10312' ,'677-10312-A-R' ,'911505097' ,'911505118' ,'677-10312' ),

('HTY1' ,'D' ,'小款' ,'中国版(CH)' ,'677-10315' ,'677-10315-A-R' ,'911503182' ,'911504612' ,'677-103157-RRD' ),
('HTY1' ,'D' ,'小款' ,'中国版(CH)' ,'677-10315' ,'677-10315-A-R' ,'911505100' ,'911505121' ,'677-10315' ),

('HTY1' ,'D' ,'小款' ,'澳洲版(AUS)' ,'677-10321' ,'677-10321-A-R' ,'911503188' ,'911504618' ,'677-103217-RRD' ),
('HTY1' ,'D' ,'小款' ,'澳洲版(AUS)' ,'677-10321' ,'677-10321-A-R' ,'911505106' ,'911505127' ,'677-10321' ),

('HTY1' ,'D' ,'小款' ,'欧洲版(EU)' ,'677-10318' ,'677-10318-A-R' ,'911503185' ,'911504615' ,'677-103187-RRD' ),
('HTY1' ,'D' ,'小款' ,'欧洲版(EU)' ,'677-10318' ,'677-10318-A-R' ,'911505103' ,'911505124' ,'677-10318' ),

('HTY1' ,'D' ,'小款' ,'印度版(IND)' ,'677-10324' ,'677-10324-A-R' ,'911503191' ,'911504621' ,'677-103247-RRD' ),
('HTY1' ,'D' ,'小款' ,'印度版(IND)' ,'677-10324' ,'677-10324-A-R' ,'911505109' ,'911505130' ,'677-10324' ),

('HTY1' ,'D' ,'中款' ,'英国版(UK)' ,'677-10327' ,'677-10327-A-R' ,'911503194' ,'911504624' ,'677-103277-RRD' ),
('HTY1' ,'D' ,'中款' ,'英国版(UK)' ,'677-10327' ,'677-10327-A-R' ,'911505112' ,'911505133' ,'677-10327' ),

('HTY2' ,'A' ,'小款' ,'美国版(US)' ,'677-10415' ,'677-10415-A-R' ,'911503195' ,'911504467' ,'1500-0AX60AC' ),
('HTY2' ,'A' ,'小款' ,'美国版ROW(US)' ,'677-10418' ,'677-10418-A-R' ,'911503198' ,'911504485' ,'1500-0AWR0AC' ),
('HTY2' ,'A' ,'小款' ,'中国版(CH)' ,'677-10421' ,'677-10421-A-R' ,'911503201' ,'911504473' ,'1500-0AWK0AC' ),
('HTY2' ,'A' ,'小款' ,'澳洲版(AUS)' ,'677-10427' ,'677-10427-A-R' ,'911503207' ,'911504476' ,'1500-0AY00AC' ),
('HTY2' ,'A' ,'小款' ,'欧洲版(EU)' ,'677-10424' ,'677-10424-A-R' ,'911503204' ,'911504470' ,'1500-0AWN0AC' ),
('HTY2' ,'A' ,'小款' ,'印度版(IND)' ,'677-10430' ,'677-10430-A-R' ,'911503210' ,'911504479' ,'1500-0AXF0AC' ),
('HTY2' ,'A' ,'中款' ,'英国版(UK)' ,'677-10433' ,'677-10433-A-R' ,'911503213' ,'911504482' ,'1500-0AWG0AC' ),


('HTY2' ,'B' ,'小款' ,'美国版(US)' ,'677-10416' ,'677-10416-A-R' ,'911503196' ,'911504468' ,'1500-0AXL0AC' ),
('HTY2' ,'B' ,'小款' ,'美国版ROW(US)' ,'677-10419' ,'677-10419-A-R' ,'911503199' ,'911504486' ,'1500-0AXG0AC' ),
('HTY2' ,'B' ,'小款' ,'中国版(CH)' ,'677-10422' ,'677-10422-A-R' ,'911503202' ,'911504474' ,'1500-0AXC0AC' ),
('HTY2' ,'B' ,'小款' ,'澳洲版(AUS)' ,'677-10428' ,'677-10428-A-R' ,'911503208' ,'911504477' ,'1500-0AWS0AC' ),
('HTY2' ,'B' ,'小款' ,'欧洲版(EU)' ,'677-10425' ,'677-10425-A-R' ,'911503205' ,'911504471' ,'1500-0AWV0AC' ),
('HTY2' ,'B' ,'小款' ,'印度版(IND)' ,'677-10431' ,'677-10431-A-R' ,'911503211' ,'911504480' ,'1500-0AWL0AC' ),
('HTY2' ,'B' ,'中款' ,'英国版(UK)' ,'677-10434' ,'677-10434-A-R' ,'911503214' ,'911504483' ,'1500-0AXH0AC' ),


('HTY2' ,'D' ,'小款' ,'美国版(US)' ,'677-10417' ,'677-10417-A-R' ,'911503197' ,'911504469' ,'1500-0AXE0AC' ),
('HTY2' ,'D' ,'小款' ,'美国版ROW(US)' ,'677-10420' ,'677-10420-A-R' ,'911503200' ,'911504487' ,'1500-0AWJ0AC' ),
('HTY2' ,'D' ,'小款' ,'中国版(CH)' ,'677-10423' ,'677-10423-A-R' ,'911503203' ,'911504475' ,'1500-0AX10AC' ),
('HTY2' ,'D' ,'小款' ,'澳洲版(AUS)' ,'677-10429' ,'677-10429-A-R' ,'911503209' ,'911504478' ,'1500-0AX50AC' ),
('HTY2' ,'D' ,'小款' ,'欧洲版(EU)' ,'677-10426' ,'677-10426-A-R' ,'911503206' ,'911504472' ,'1500-0AX20AC' ),
('HTY2' ,'D' ,'小款' ,'印度版(IND)' ,'677-10432' ,'677-10432-A-R' ,'911503212' ,'911504481' ,'1500-0AXB0AC' ),
('HTY2' ,'D' ,'中款' ,'英国版(UK)' ,'677-10435' ,'677-10435-A-R' ,'911503215' ,'911504484' ,'1500-0AXP0AC' )
--
('HTY3' ,'A' ,'小款' ,'美国版(US)' ,'677-10219' ,'677-10219-A-R' ,'911503216' ,'911504678' ,'677-10219-RRD' ),
('HTY3' ,'A' ,'小款' ,'美国版ROW(US)' ,'677-10222' ,'677-10222-A-R' ,'911503219' ,'911504680' ,'677-10222-RRD' ),
('HTY3' ,'A' ,'小款' ,'中国版(CH)' ,'677-10225' ,'677-10225-A-R' ,'911503222' ,'911504682' ,'677-10225-RRD' ),
('HTY3' ,'A' ,'小款' ,'澳洲版(AUS)' ,'677-10231' ,'677-10231-A-R' ,'911503228' ,'911504686' ,'677-10231-RRD' ),
('HTY3' ,'A' ,'小款' ,'欧洲版(EU)' ,'677-10228' ,'677-10228-A-R' ,'911503225' ,'911504684' ,'677-10228-RRD' ),
('HTY3' ,'A' ,'小款' ,'印度版(IND)' ,'677-10234' ,'677-10234-A-R' ,'911503231' ,'911504688' ,'677-10234-RRD' ),
('HTY3' ,'A' ,'中款' ,'英国版(UK)' ,'677-10237' ,'677-10237-A-R' ,'911503234' ,'911504690' ,'677-10237-RRD' ),

('HTY3' ,'B' ,'小款' ,'美国版(US)' ,'677-10220' ,'677-10220-A-R' ,'911503217' ,'911504679' ,'677-10220-RRD' ),
('HTY3' ,'B' ,'小款' ,'美国版ROW(US)' ,'677-10223' ,'677-10223-A-R' ,'911503220' ,'911504681' ,'677-10223-RRD' ),
('HTY3' ,'B' ,'小款' ,'中国版(CH)' ,'677-10226' ,'677-10226-A-R' ,'911503223' ,'911504683' ,'677-10226-RRD' ),
('HTY3' ,'B' ,'小款' ,'澳洲版(AUS)' ,'677-10232' ,'677-10232-A-R' ,'911503229' ,'911504687' ,'677-10232-RRD' ),
('HTY3' ,'B' ,'小款' ,'欧洲版(EU)' ,'677-10229' ,'677-10229-A-R' ,'911503226' ,'911504685' ,'677-10229-RRD' ),
('HTY3' ,'B' ,'小款' ,'印度版(IND)' ,'677-10235' ,'677-10235-A-R' ,'911503232' ,'911504689' ,'677-10235-RRD' ),
('HTY3' ,'B' ,'中款' ,'英国版(UK)' ,'677-10238' ,'677-10238-A-R' ,'911503235' ,'911504691' ,'677-10238-RRD' ),





