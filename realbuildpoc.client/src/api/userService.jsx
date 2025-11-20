import axios from "axios";

const API_URL = import.meta.env.VITE_API_URL;

export const getAllUsers = async () => {
    try {
        const response = await axios.get(`${API_URL}/User/get-all`);
        return response.data;
    } catch (error) {
        console.error("Error fetching users:", error);
        throw error;
    }
};
