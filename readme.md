# Car Rental Service

Entities:

- Car (model, license plate, rental price, status, etc.)
- Customer (name, driver's license, payment info, etc.)
- Reservation (start date, end date, car ID, customer ID, etc.)
- RentalAgreement (terms, insurance info, mileage, etc.)
- Payment (amount, method, date, etc.)

Capabilities

**Search for Available Cars**: Users can filter cars by attributes like model, price, availability dates, or car category (e.g., SUV, sedan, electric).

**Make a Reservation**: Users can book a car by specifying rental start and end dates, selecting the desired car, and providing customer details.

**Manage Reservations**: Users can view, modify, or cancel their existing reservations. This might involve changing the rental period or swapping to a different car model.

**Complete Payment**: Users can pay for their rental using various methods (e.g., credit card, digital wallets, etc.) and receive payment confirmation.

**Pick-Up and Drop-Off Coordination**: Users can schedule pick-up and drop-off times and locations, track their upcoming rentals, or check instructions for retrieving the car.

## Navigation properties

handling navigation between related entities in a rich domain model can create challenges, particularly in terms of performance and clarity. Overloading the database with eager loading or introducing pitfalls with lazy loading are issues many developers face. To address this, here are some alternative approaches that balance safety, performance, and maintainability:

---

### 1. **Use Aggregate Roots to Define Boundaries**
   In **Domain-Driven Design (DDD)**, the concept of **aggregate roots** is key. Each aggregate root is a cluster of related entities treated as a single unit of consistency. By focusing on accessing and modifying aggregates as a whole, you can reduce the need for deep navigation.

   For example:
   - The `Reservation` entity can be an aggregate root, encapsulating relevant data like `Car` and `Customer` references, without requiring deep navigation to unrelated reservations or cars.
   - Instead of navigating from a `Reservation` to a `Car`, you could expose the `CarId` in the `Reservation` as a value object and query for the specific car if needed.

   This prevents loading unrelated data and clarifies the ownership of entities within a transactional boundary.

---

### 2. **Apply CQRS (Command Query Responsibility Segregation)**
   With **CQRS**, you can separate **read models** and **write models**, tailoring the data structure for each use case:
   - **Write Model**: Defines the relationships between entities and enforces domain rules.
   - **Read Model**: Simplifies fetching data by flattening and denormalizing relationships.

   For instance, you could create a read model specifically for fetching reservation details along with car and customer information, preloading only the relevant data. This eliminates the need for lazy-loading tricks while keeping the write model clean.

---

### 3. **Explicit Projections and DTOs**
   Instead of loading entire entities with navigational properties, use **Data Transfer Objects (DTOs)** or **projections**:
   - A `ReservationDetailsDTO` could combine data from the `Reservation`, `Car`, and `Customer` entities without retrieving full objects.
   - Use queries tailored for the task at hand (e.g., `JOIN` queries in SQL or ORM projections) to avoid unnecessary loading.

   This makes the data fetching explicit and avoids hidden behaviors like lazy loading.

---

### 4. **Domain Events for Cross-Aggregate Communication**
   When there is a need to coordinate between related entities that belong to separate aggregates, you can use **domain events**:
   - For example, when a `Reservation` is confirmed, you could trigger an event notifying the `Car` aggregate to update its availability.
   - This approach avoids direct navigation and keeps aggregates decoupled, while ensuring consistency through asynchronous communication.

---

### 5. **Repository Design with Query Specifications**
   Specifications can still be useful when applied thoughtfully:
   - The repository pattern can include methods that explicitly describe what is fetched, e.g., `GetReservationWithCarAndCustomer(int reservationId)`.
   - This avoids generic lazy-loading behavior and ensures developers know what is being loaded.

---

Each of these strategies has trade-offs, but combining **aggregate roots**, **CQRS**, and **explicit projections** tends to strike a healthy balance.

## Aggregate Roots

The aggregate roots in the **Car Rental Service** domain based on the scenarios and responsibilities mentioned. Aggregate roots should be chosen carefully to ensure consistency boundaries and manageable transactional scope:

### Suggested Aggregate Roots:

1. **Reservation**:
   - **Why**: A reservation encapsulates the process of booking a car, managing the rental period, and associating the customer. It’s central to the system's functionality and governs the interactions between `Car`, `Customer`, and payment details.
   - **Contained Entities**: 
     - References or value objects: `CarId`, `CustomerId`, `PaymentDetails`.
     - Possibly other details like rental terms.
   - **Boundaries**: The aggregate should not include full navigation to cars or customers but instead use identifiers (e.g., `CarId` and `CustomerId`) for external lookups when needed.

2. **Car**:
   - **Why**: The `Car` entity represents the physical vehicle and its availability. It has its own lifecycle (e.g., status updates for maintenance or rentals) and needs transactional consistency when updated.
   - **Contained Entities**:
     - Status (e.g., `Available`, `Reserved`, `UnderMaintenance`).
     - Attributes like model, category, or mileage.
   - **Boundaries**: Reservations that involve this car are external; the car’s aggregate may react to domain events triggered by reservations.

3. **Customer**:
   - **Why**: The `Customer` entity represents a person interacting with the system. It captures personal details, preferences, and historical transactions (e.g., past reservations).
   - **Contained Entities**:
     - Profile data (name, contact information, driver's license, etc.).
   - **Boundaries**: While linked to reservations, the customer aggregate should focus on its own lifecycle rather than directly managing reservations.

4. **Payment**:
   - **Why**: Payments need their own aggregate to ensure consistency in financial transactions, processing methods, and status updates (e.g., `Pending`, `Completed`, `Failed`).
   - **Contained Entities**:
     - Transaction details, amount, method.
   - **Boundaries**: Payments can reference reservations but remain independent from their lifecycle.


### Interaction Between Aggregates:
- **Reservation triggers changes**: For example, confirming a reservation triggers updates in the `Car` aggregate (availability) and potentially the `Payment` aggregate (transaction completion).
- **Event-driven coordination**: Use domain events to signal updates across aggregates, e.g., a `ReservationConfirmed` event can notify the `Car` aggregate to mark itself as reserved.

## Primitive vs Typed Id's

When comparing `CarId` (a struct) versus an `int` as the type for the `Id` property in the `Car` class, the location of the value in memory depends on the nature of the class and its usage. Here's a breakdown:

---

### 1. **Memory Layout for `class Car`**
   - A `class` in C# is a **reference type**. Instances of `Car` are stored on the **heap**, and its properties are stored alongside the object on the heap.

---

### 2. **`public int Id { get; private set; }`**
   - **Memory Behavior**: 
     - `Id` is a primitive value type (`int`), so its 32-bit value is stored directly as part of the `Car` object on the heap.  
     - For example, if `Car` has other properties, all primitive value types (like `int`, `bool`, etc.) are stored inline within the same memory block as the `Car` object.

---

### 3. **`public CarId Id { get; private set; }`**
   - **Memory Behavior**:
     - `CarId` is a **struct**, which is also a value type. However, its memory footprint includes the `int` field (`Value`) and potentially additional metadata, as it's a custom type.
     - Like the `int`, the entire `CarId` struct will be stored inline within the `Car` object on the heap.

---

### Comparison Summary:
Structs like `CarId` are still **value types**, so their memory layout is similar to primitive value types like `int`. When embedded in a reference type (`Car`), both the `int` and the `CarId` fields are stored **inline on the heap with the containing object**.

---

### Memory Usage Differences:
1. **`int`**:  
   - Occupies 4 bytes (32 bits) for its raw value.

2. **`CarId` (Struct)**:  
   - At minimum, it will occupy 4 bytes for the `int` field plus potential extra memory for struct metadata (e.g., padding for alignment).  
   - If `CarId` includes additional logic or fields, its memory footprint will increase accordingly.

---

### Key Insights:
- If you need **type safety and domain clarity**, a lightweight struct like `CarId` provides significant benefits, with minimal overhead in memory.
- If you prioritize **raw performance and simplicity**, sticking to `int` might be more efficient, particularly in performance-critical scenarios with high memory constraints.


## Good will

```C#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.ConfigureWarnings(warning => 
            warning.Throw(RelationalEventId.QueryClientEvaluationWarning));
}
```