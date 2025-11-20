////import React, { useEffect, useState } from "react";
////import { getAllUsers } from "../api/userService";

////function Users() {
////    const [users, setUsers] = useState([]);
////    const [loading, setLoading] = useState(true);

////    useEffect(() => {
////        fetchUsers();
////    }, []);

////    const fetchUsers = async () => {
////        try {
////            const res = await getAllUsers();
////            setUsers(res.data); // Because ApiResponse { success, message, data }
////        } catch (error) {
////            alert("Failed to load users");
////        } finally {
////            setLoading(false);
////        }
////    };

////    if (loading) return <p>Loading...</p>;

////    return (
////        <div>
////            <h2>User List</h2>
////            {users.length === 0 ? (
////                <p>No users found.</p>
////            ) : (
////                <ul>
////                    {users.map((u) => (
////                        <li key={u.id}>
////                            {u.fullName} — {u.email}
////                        </li>
////                    ))}
////                </ul>
////            )}
////        </div>
////    );
////}

////export default Users;



import React, { useEffect, useState } from "react";
import { getAllUsers } from "../api/userService";

function Users() {
    const [user, setUser] = useState(null);

    useEffect(() => {
        loadUser();
    }, []);

    const loadUser = async () => {
        try {
            const result = await getAllUsers();
            setUser(result);
            console.log("User:", result);
        } catch (err) {
            console.error("Failed to load user:", err);
        }
    };

    if (!user) return <h3>Loading...</h3>;

    return (
        <div>
            <h2>User Details</h2>
            <p><strong>ID:</strong> {user.id}</p>
            <p><strong>Name:</strong> {user.fullName}</p>
            <p><strong>Email:</strong> {user.email}</p>
        </div>
    );
}

export default Users;
