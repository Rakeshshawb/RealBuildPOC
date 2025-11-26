import axios from "axios";


const API = import.meta.env.VITE_API_URL;


export const getAllUsers = async () => {
    const res = await axios.get(`${API}`);
    return res.data;
};