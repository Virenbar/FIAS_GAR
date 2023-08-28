MERGE INTO 
    <target> AS T
USING
    <source> AS S 
ON (T.id = S.id)
WHEN NOT MATCHED BY TARGET THEN
    INSERT (<insert>)
    VALUES (<values>)
WHEN MATCHED THEN
    UPDATE SET <update>;