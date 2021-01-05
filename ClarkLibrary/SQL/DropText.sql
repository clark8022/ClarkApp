﻿SELECT sys.schemas.name + '.' + sys.objects.name AS name
	,CASE Type
		WHEN 'P'
			THEN 'Drop procedure '
		WHEN 'V'
			THEN 'Drop View '
		WHEN 'FN'
			THEN 'Drop function '
		WHEN 'TR'
			THEN 'Drop trigger '
		WHEN 'TF'
			THEN 'Drop function '
		WHEN 'IF'
			THEN 'Drop function '
		END AS DropText
FROM sys.objects
INNER JOIN sys.schemas ON sys.objects.schema_id = sys.schemas.schema_id
WHERE type IN (
		'V'
		,'P'
		,'FN'
		,'TR'
		,'TF'
		,'IF'
		)
	AND (
		sys.objects.name NOT LIKE 'sys%'
		OR sys.objects.name LIKE '%ystem_SpellTheNumber%'
		OR sys.objects.name LIKE '%ystem_GetDefaultDepartmentID%'
		OR sys.objects.name LIKE '%ystem_FriendlyAmount'
		OR sys.objects.name LIKE '%ystem_GetDefaultCountryID%'
		)
	AND sys.objects.name NOT LIKE 'dt_%'
	AND sys.objects.name NOT LIKE 'x_x_%'
	AND sys.objects.name NOT LIKE 'fn_%'
	AND sys.objects.name NOT LIKE 'cfv%'
	AND sys.objects.name NOT LIKE 'sp_dropdiagram%'
	AND sys.objects.name NOT LIKE 'sp_renamediagram%'
	AND sys.objects.name NOT LIKE 'sp_creatediagram%'
	AND sys.objects.name NOT LIKE 'sp_helpdiagram%'
	AND sys.objects.name NOT LIKE 'sp_upgraddiagrams%'
	AND sys.objects.name NOT LIKE 'Order_GetOrderInfoActionRule_archive%'
	AND sys.objects.name NOT LIKE 'Order_GetOrderInfoAxysTransactions_archive%'
	AND sys.objects.name NOT LIKE 'x_v_cashtransactions_archive%'
	AND sys.objects.name NOT LIKE 'Order_GetOrderInfoCashTransactions_archive%'
	AND sys.objects.name NOT LIKE 'Finance_Transactions_List_archive%'
	AND sys.objects.name NOT LIKE 'Order_GetOrderInfoFinanceTransactions_archive%'
	AND sys.objects.name NOT LIKE 'Order_GetOrderInfoOrderDetails_archive%'
	AND sys.objects.name NOT LIKE 'Order_GetOrderInfoOrderStatusHist_archive%'
	AND sys.objects.name NOT LIKE 'x_v_Payments_archive%'
	AND sys.objects.name NOT LIKE 'Order_GetOrderInfoPaymentTransactions_archive%'
	AND sys.objects.name NOT LIKE 'Portfolio_GetOneExportTransaction_archive%'
	AND sys.objects.name NOT LIKE 'x_v_OrderExternal_A%'
	AND sys.objects.name NOT LIKE 'x_v_Payment_archive%'
	AND sys.objects.name NOT LIKE 'x_t_OrderTrail_archive%'
	AND sys.objects.name NOT LIKE 'x_v_orderstatusdata_archive%'
	AND sys.objects.name NOT LIKE 'x_T_UserSharingTrail_archive%'
	AND NOT (
		sys.objects.name LIKE '%CustomField'
		AND sys.schemas.name = 'TRXApi'
		)
	AND sys.objects.name NOT LIKE 'NPO_%'
	AND sys.objects.name NOT LIKE 'AMALTA_%'
	AND sys.objects.name NOT LIKE 'GPS_%'
	AND sys.objects.name NOT LIKE 'ACTA_%'
	AND sys.objects.name NOT LIKE 'TEST_%'
	AND sys.objects.name NOT LIKE 'SSB_%'
	AND sys.objects.name NOT LIKE 'Formue_%'
	AND sys.objects.name NOT LIKE 'spx_acta_%'
	AND sys.objects.name NOT LIKE 'sp_alterdiagram%'
	AND sys.objects.name NOT LIKE '%tradestore%'
	AND sys.objects.name NOT LIKE 'Orkla_%'
	AND sys.objects.name NOT LIKE 'Dimension_%'
	AND sys.objects.name NOT LIKE 'SNS_%'
	AND sys.objects.name NOT LIKE 'OF_%'
	AND sys.objects.name NOT LIKE 'FPB_%'
	AND sys.objects.name NOT LIKE 'First[_]%'
	AND sys.objects.name NOT LIKE 'Catella_%'
	AND sys.objects.name NOT LIKE '%abasec_%'
	AND sys.objects.name NOT LIKE 'Cat[_]%'
	AND sys.objects.name NOT LIKE 'PAR[_]%'
	AND sys.objects.name NOT LIKE 'SB1[_]%'
	AND sys.objects.name NOT LIKE 'X_V_STandardCrmT;oTradex'
	AND sys.objects.name NOT LIKE 'sp_StandardCrmToTradex'
	AND sys.objects.name NOT LIKE 'Custom[_]%'
	AND sys.objects.name NOT LIKE 'OPT[_]%'
ORDER BY type DESC
