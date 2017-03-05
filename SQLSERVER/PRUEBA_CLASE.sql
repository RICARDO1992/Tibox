SELECT * FROM Customer;
select * from [dbo].[Order]
OrderByOrderNumber
SELECT * FROM [dbo].[Order] WHERE ID= 830
SELECT * FROM [dbo].[OrderItem] WHERE OrderId = 830

 dbo.OrderWithOrderItems	

-- dbo.CustomerWithOrders 1

-- buscar las ordenes por OrderNumber
--- una orden puede tener muchas items

-- 1. Crear el IOrderRepository
-- 2. Implementar interfaz IOrderRepository
-- 3. Modificar UnitOfWork para usar la interfaz creada.
-- 4. Crear 2 SP,
-- 	   > OrderByOrderNumber
-- 	   > OrderWithOrderItems
-- 5. Crear las pruebas unitarias de Order

