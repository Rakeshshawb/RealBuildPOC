import axios from "axios";

const API_URL = "https://localhost:7039/api/AdminSeller/InsertOrganization"; // change if needed

// ----------------------------------------
// Create Organization
// ----------------------------------------
export const createOrganization = async (data) => {
    try {
        const token = localStorage.getItem("token");

        const res = await axios.post(`${API_URL}/create`, data, {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });

        return res.data;
    } catch (err) {
        throw err.response?.data || "Organization registration failed";
    }
};
