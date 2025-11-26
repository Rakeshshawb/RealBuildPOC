import { useEffect, useState } from "react";
import { getAllUsers } from "../api/userService";


export default function Users() {
    const [users, setUsers] = useState([]);


    useEffect(() => {
        load();
    }, []);


    const load = async () => {
        try {
            const data = await getAllUsers();
            setUsers([data]);
        } catch (err) {
            console.error("Failed:", err);
        }
    };


    return (
        <>
            <h2>User List</h2>
            {users.map(u => (
                <p key={u.id}>{u.fullName} — {u.email}</p>
            ))}
        </>
    );
}