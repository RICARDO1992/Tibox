SELECT * FROM Customer;

-- dbo.CustomerWithOrders 1

-- buscar las ordenes por OrderNumber
--- una orden puede tener muchas items

-- 1. Crearel IOrderRepository
-- 2. Implementar interfaz IOrderRepository
-- 3. Modificar UnitOfWork para usar la interfaz creada.
-- 4. Crear 2 SP,
-- 	   > OrderByOrderNumber
-- 	   > OrderWithOrderItems
-- 5. Crear las pruebas unitarias de Order


